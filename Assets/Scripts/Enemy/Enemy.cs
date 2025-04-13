using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float timer = 3f;
    public float minTimer = 3f;
    public float maxTimer = 9f;

    public float damage = 25f;
    public float speedMove = 5f;
    public float rotateAngle = 0.5f;
    public float minDisFollow = 15f;
    public float minDisLookTarget = 20f;
    public float minDisAttack = 1f;
    public float minDisRandomMove = 3f;
    public float maxDisRandomMove = 14f;

    public float minAngleRotate = 30f;
    public float maxAngleRotate = 120f;

    private bool isFollow = false;
    private bool isRandomMove = false;
    private bool isAttack = false;

    private Quaternion targetRandomRotate;
    private Vector3 targetRandomPosition;
    private CharacterMove charak;
    private Transform trChar;
    private Transform trEnemy;
    private Rigidbody rbEnemy;
    private AnimEnemy anim;
    private CharacterHp hpChar;
    private void Awake()
    {
        hpChar = FindObjectOfType<CharacterHp>();
        charak = FindObjectOfType<CharacterMove>();
        trChar = charak.GetComponent<Transform>();
        trEnemy = GetComponent<Transform>();
        rbEnemy = GetComponent<Rigidbody>();
        anim = GetComponent<AnimEnemy>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttack = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttack = false;
        }
    }
    public void Disable(bool isDisabled)
    {
        enabled = isDisabled;
    }
    private void Update()
    {
        FollowTarget();
        Attack();
    }
    private void LateUpdate()
    {
        LookTarget();
    }
    private void FixedUpdate()
    {
        RandomTimer();
        RandomMove();
        RandomRotate();
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }

    private bool IsMinDistance(float minDis)
    {
        float distance = Vector3.Distance(trEnemy.position, trChar.position);
        if (distance <= minDis) return true;
        else return false;
    }
    private void LookTarget()
    {
        if (IsMinDistance(minDisLookTarget))
        {
            Vector3 diractionTarget = trChar.position - trEnemy.position;
            diractionTarget.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(diractionTarget, Vector3.up);
            trEnemy.rotation = Quaternion.Slerp(trEnemy.rotation, targetRotation, Time.deltaTime * rotateAngle);
        }
    }
    private void FollowTarget()
    {
        if (IsMinDistance(minDisFollow))
        {
            trEnemy.position = Vector3.MoveTowards(trEnemy.position, trChar.position, speedMove * Time.deltaTime);
            anim.MoveAnim(1);
            isFollow = true;
        }
        else if(!isRandomMove)
        {
            anim.MoveAnim(0);
            isFollow = false;
        }
    }
    private async void Attack()
    {
        if (IsMinDistance(minDisAttack))
        {
            anim.AttackAnim(true);
            hpChar.TakeDamage(damage);
            await Task.Delay(1000);
        }
        else
        {
            anim.AttackAnim(false);
        }
    }
    private void RandomMove()
    {
        if(!isFollow && isRandomMove)
        {
            rbEnemy.MovePosition(rbEnemy.position + trEnemy.forward * Time.fixedDeltaTime * speedMove);
            anim.MoveAnim(1);
            StartCoroutine(Trisheld());
        }
        else if(!isFollow)
        {
            anim.MoveAnim(0);
            StopCoroutine(Trisheld());
        }
    }

    private void SetRandomTargetRotate()
    {
        float currentY = trEnemy.eulerAngles.y;
        float randomY = Random.Range(minAngleRotate, maxAngleRotate);
        if (Random.value > 0.5f)
        {
            randomY *= -1;
        }
        float newY = randomY + currentY;
        targetRandomRotate = Quaternion.Euler(new Vector3(0f, newY, 0f));
    }
    private void RandomRotate()
    {
        Quaternion newRotate = Quaternion.Slerp(trEnemy.rotation, targetRandomRotate, rotateAngle * Time.fixedDeltaTime);
        rbEnemy.MoveRotation(newRotate);
    }
    private void RandomTimer()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SetRandomTargetRotate();
            timer = Random.Range(minTimer, maxTimer);
            isRandomMove = true;
        }
    }
    private IEnumerator Trisheld()
    {
            yield return new WaitForSeconds(Random.Range(10, 15));
            isRandomMove = false;
    }
}
