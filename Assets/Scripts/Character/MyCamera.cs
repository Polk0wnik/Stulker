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
    {   //Получаем расстояние между камерой и игроком при старте игры
        offset = cameraTR.position - playerTR.position;
    }
    private void LateUpdate()
    {
        FollowCamera();
    }
    private void FollowCamera()
    {   //Вращаем камеру через углы Эйлера 
        cameraTR.localEulerAngles = InputCamera();
        //Указываем новую позицию камеры, относительно позиции игрока и с отступом от игрока и углом вращения 
        cameraTR.position = playerTR.position + cameraTR.localRotation * offset;
    }
        private Vector3 InputCamera()
        {   //Получаем направление движение мыши в переменые с типом float, значение которых от -1 до 1
            vertical -= Input.GetAxis("Mouse Y") * sensitivity; 
            horysontal += Input.GetAxis("Mouse X") * sensitivity;
            //Ограничеваем вращение по вертикали от -90 до 90 градусам
            vertical = Mathf.Clamp(vertical, minAngle, maxAngle);
            //Указываем направление движение мышки в Vector3 по осям вращения ч-г
            return new Vector3(vertical, horysontal, 0);
        }
    
}
