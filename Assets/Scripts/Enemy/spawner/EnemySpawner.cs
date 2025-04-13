using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public readonly List<Transform> points = new List<Transform>();
    public readonly List<HpEnemy> enemes = new List<HpEnemy>();
    public GameObject enemyPrefab;
    private Vector3 currentPoint;
    private Quaternion direction;
    public int enemyAmmoutStarted = 3;
    private void Awake()
    {
        points.AddRange(GetComponentsInChildren<Transform>());
        for (int i = 0; i < enemyAmmoutStarted; i++)
        {
            Spawn();
        }
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        
    }
    private void Start()
    {
        enemes.AddRange(FindObjectsOfType<HpEnemy>());
    }
    private void SetRandomPoint()
    {
        int index = Random.Range(0, points.Count);
        currentPoint = points[index].position;
        direction = points[index].rotation;
    }
    private void Spawn()
    {
        SetRandomPoint();
        Instantiate(enemyPrefab, currentPoint, direction);
    }
    private void ChekEnemyDead()
    {
        foreach(var Enemy in enemes)
        {
            if(Enemy.isDead)
            {
                Debug.Log("Active: new Enemy");
                Enemy.gameObject.SetActive(true);
                SetRandomPoint();
                Enemy.transform.position = currentPoint;
            }
        }
    }
    public IEnumerator WaitTimeSpawn()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Spawn Enemy");
        ChekEnemyDead();
    }
}
