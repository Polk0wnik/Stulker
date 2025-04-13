using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpEnemy : MonoBehaviour
{
    private EnemySpawner spawner;
    private Image hpChar;
    private float currentHp = 100f;
    private AnimEnemy animEnemy;
    private Enemy enemy;
    private Rigidbody rb;
    private Collider Col;
    public bool isDead = false;
    private void Awake()
    {
        spawner = FindObjectOfType<EnemySpawner>();
        hpChar = GetComponentInChildren<Image>();
        Time.timeScale = 1;
        animEnemy = GetComponent<AnimEnemy>();
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody>();
        Col = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        Inactive(false);
        currentHp = 100f;
    }
    private void Update()
    {
        hpChar.fillAmount = currentHp / 100f;
    }
    public void TakeDamage(float damage)
    {
        if (currentHp > 1)
        {
            currentHp -= damage;
        }
        else
        {
            animEnemy.AnimDied();
            StartCoroutine(WaitTimeDeath());
            StartCoroutine(spawner.WaitTimeSpawn());
        }
    }
    private void Inactive(bool isActive)
    {
        enemy.Disable(!isActive);
        enabled = !isActive;
        rb.isKinematic = isActive;
        Col.enabled = !isActive;
        isDead = isActive;
    }
    private IEnumerator WaitTimeDeath()
    {
        Inactive(true);
        yield return new WaitForSeconds(2.8f);
        gameObject.SetActive(false);
    }
}