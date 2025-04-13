using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollader : MonoBehaviour
{
    public Rigidbody rbPlayer;
    public Transform trPlayer;
    private Transform trWater;
    private bool isWater;
    public float coefficient = 6f;
    public float maxHeight = 1.5f;

    private void Awake()
    {
        trWater = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isWater = true;
            rbPlayer.drag = 2 * maxHeight;
            rbPlayer.angularDrag = 2 * maxHeight;
        }
    }
    private void FixedUpdate()
    {
        Vector3 input = rbPlayer.velocity;
        if (input.y < 0.9f && isWater && !Input.GetKey(KeyCode.LeftControl))
        {
            float height = (trWater.position.y) - maxHeight;
            height = height < trPlayer.position.y ? 0 : 1;
            rbPlayer.AddForce(Vector3.up * height * coefficient, ForceMode.Impulse);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isWater = false;
            rbPlayer.drag = 0;
            rbPlayer.angularDrag = 0;
        }
    }
}
