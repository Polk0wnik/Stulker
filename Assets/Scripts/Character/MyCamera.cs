using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    private Transform cameraTR;
    public Transform playerTR;
    public float minAngle = -70f;
    public float maxAngle = 70f;
    private float vertical;
    private float horysontal;
    public float sensitivity = 5f;
    private Vector3 offset;
    

    private void Awake()
    {
        cameraTR = GetComponent<Transform>();
    }
    private void Start()
    {   //�������� ���������� ����� ������� � ������� ��� ������ ����
        offset = cameraTR.position - playerTR.position;
    }
    private void LateUpdate()
    {
        FollowCamera();
    }
    private void FollowCamera()
    {   //������� ������ ����� ���� ������ 
        cameraTR.localEulerAngles = InputCamera();
        //��������� ����� ������� ������, ������������ ������� ������ � � �������� �� ������ � ����� �������� 
        cameraTR.position = playerTR.position + cameraTR.localRotation * offset;
    }
        private Vector3 InputCamera()
        {   //�������� ����������� �������� ���� � ��������� � ����� float, �������� ������� �� -1 �� 1
            vertical -= Input.GetAxis("Mouse Y") * sensitivity; 
            horysontal += Input.GetAxis("Mouse X") * sensitivity;
            //������������ �������� �� ��������� �� -90 �� 90 ��������
            vertical = Mathf.Clamp(vertical, minAngle, maxAngle);
            //��������� ����������� �������� ����� � Vector3 �� ���� �������� �-�
            return new Vector3(vertical, horysontal, 0);
        }
    
}
