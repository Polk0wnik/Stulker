using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEnemy : MonoBehaviour
{
    private Animator animEnemy;
    public float speedAnim = 1f;
    private void Awake()
    {
        animEnemy = GetComponent<Animator>();
    }
    public void AnimDied()
    {
        animEnemy.SetTrigger("deadTrigger");
    }
    public void MoveAnim(float move)
    {
        animEnemy.SetFloat("speed", move*speedAnim, 0.1f, Time.deltaTime);
    }
    public void AttackAnim(bool isAttack)
    {
        animEnemy.SetBool("isAttack", isAttack);
    }
}
