using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private RaycustCharacter ray;
    public float damage = 20;
    private float nextTime;
    private float intervalTime = 1;
    public float coeficent = 5;
    private void Awake()
    {
        ray = FindObjectOfType<RaycustCharacter>();
    }
    private void Update()
    {
        if(Input.GetMouseButton(0) && Time.time > nextTime) 
        {
            nextTime = Time.time + intervalTime / coeficent;
            ray.Shouting(damage);
        }
    }
}
