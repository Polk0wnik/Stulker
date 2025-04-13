using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCharacter : MonoBehaviour
{
    private Animator animator;
    public float switchMove;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void MoveAnim(Vector3 inputAxis)
    {
        switchMove = Input.GetKey(KeyCode.LeftControl) ? 0.5f : 1f;
        if(inputAxis.sqrMagnitude > 0)
        {
            animator.SetFloat("horizontal", inputAxis.x * switchMove, 0.2f , Time.deltaTime);
            animator.SetFloat("vertical", inputAxis.z * switchMove, 0.2f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("horizontal", 0, 0.2f, Time.deltaTime);
            animator.SetFloat("vertical", 0, 0.2f, Time.deltaTime);
        }
    }
    public void JumpAnim(bool isJump)
    {
        if(isJump)
        {
            animator.SetTrigger("isJump");
        }
    }
    public void RifleAnim(bool isRifle)
    {
        animator.SetBool("isRifle", isRifle);
    }
}