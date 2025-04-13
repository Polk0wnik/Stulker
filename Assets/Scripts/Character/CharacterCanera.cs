using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCanera : MonoBehaviour
{
    private Transform cameraTR;
    public Transform playerTR;
    private float vertical;
    private float horysontal;
    public float sensitivity = 5f;
    private Vector3 offset;
    

    private void Awake()
    {
        cameraTR = GetComponent<Transform>();
    }
    private void Start()
    {
        offset = cameraTR.position - playerTR.position;
    }
    private void LateUpdate()
    {
        FollowCamera();
    }
    private void FollowCamera()
    {
        cameraTR.position = playerTR.position + offset;
    }
    private Vector3 InputCamera()
    {
        vertical -= Input.GetAxis("Mouse Y")*sensitivity;
        horysontal += Input.GetAxis("Mouse X")*sensitivity;
        return new Vector3(vertical, horysontal, 0);
    }
}
