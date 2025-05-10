using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMechEffect : MonoBehaviour
{
    private MeshRenderer fireMesh;
    public List<Material> fireMaterials = new List<Material>();
    private Transform fireTrans;
    private float time = 0f;
    private void Awake()
    {
        fireMesh = GetComponent<MeshRenderer>();
        fireTrans = GetComponent<Transform>();
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        ShowFireMesh();
    }
    public void DisableFireMech(float nextTime)
    {
        if(Time.time > time)
        {
            time = nextTime;
            gameObject.SetActive(false);
            // ������� ������ ��������
        }
    }
    public void EnableFireMech(bool isButtonPressed)
    {
        if(isButtonPressed)
        {
            Debug.Log("WOW");
            gameObject.SetActive(true);
            // ������� ������ �������
        }
    }
    private void ShowFireMesh()
    {
        fireTrans.localScale = Vector3.zero;
        int index = Random.Range(0, fireMaterials.Count);
        // �������� ���������
        fireMesh.sharedMaterial = fireMaterials[index];
        // ������ �������
        fireTrans.localScale *= Random.Range(0.3f, 0.6f);
        //������ ��������
        fireTrans.localRotation *= Quaternion.AngleAxis(Random.value*360f, Vector3.forward);
    }
}
