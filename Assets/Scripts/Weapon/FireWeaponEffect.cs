using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeaponEffect : MonoBehaviour
{
    private FireMechEffect fireMech;
    public GameObject fireGB;
    private AudioSource sourse;
    public AudioClip click;
    private float time = 0f;
    public float interval = 0.2f;
    private bool isFire = false;
    private void Awake()
    {
        sourse = GetComponent<AudioSource>();
        fireMech = GetComponentInChildren<FireMechEffect>();
    }
    private void Update()
    {
        FireAudio();
    }
    private void FireAudio()
    {
        if(Input.GetMouseButton(0) && Input.GetMouseButton(1) && Time.time > time) 
        {
            isFire = true;
            sourse.PlayOneShot(click);
            fireGB.SetActive(true);
            time = Time.time + interval;
        }
        else
        {
            fireMech.DisableFireMech(time);
            isFire = false;
        }
    }

}
