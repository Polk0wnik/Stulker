using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody rbPers;
    private MyCamera camera_;
    private AnimCharacter anim;
    private RaycustCharacter ray;
    public float speedMove = 6f;
    public float jumpStrenj = 4f;
    private bool isTerra = false;

    private void Awake()
    {
        rbPers = GetComponent<Rigidbody>();
        anim = GetComponent<AnimCharacter>();
        camera_ = FindObjectOfType<MyCamera>();
        ray = FindObjectOfType<RaycustCharacter>();
    }
    private void FixedUpdate()
    {
        Vector3 inputAxis = InputAxis();
        anim.MoveAnim(inputAxis);
        Vector3 newDirection = Rotate(inputAxis);
        Move(newDirection);
        bool isRayfl = ray.isPickWeapon;
        anim.RifleAnim(isRayfl);
    }
    private void Update()
    {
        Jump();
    }
    private void Move(Vector3 inputAxis)
    {
        speedMove = Input.GetKey(KeyCode.LeftControl) ? 3f : 6f;
        rbPers.MovePosition(rbPers.position+ inputAxis * speedMove*Time.deltaTime);
    }
    private Vector3 Rotate(Vector3 inputAxis)
    {
        Vector3 fZ = Vector3.ProjectOnPlane(camera_.transform.forward, Vector3.up).normalized;
        Vector3 rX = Vector3.ProjectOnPlane(camera_.transform.right, Vector3.up).normalized;
        Vector3 newDirection = (inputAxis.z * fZ) + (inputAxis.x * rX);
        Quaternion rotate = Quaternion.LookRotation(fZ,Vector3.up);
        rbPers.MoveRotation(rotate);
        return newDirection;
    }    
    private Vector3 InputAxis()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        return new Vector3(x, 0, z);
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isTerra)
        {
            rbPers.AddForce(Vector3.up * jumpStrenj, ForceMode.Impulse);
            anim.JumpAnim(isTerra);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terra")
        {
            isTerra = true;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Terra")
        {
            isTerra = false;

        }
    }
}
