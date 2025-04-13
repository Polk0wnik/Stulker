using UnityEngine;

public class RaycustCharacter : MonoBehaviour
{
    public Ray ray;
    private RaycastHit hit;
    public LayerMask layerEnemy;
    public LayerMask layerItem;
    private bool isHit;
    public float rayLengs = 20f;
    private WeaponHand weaponHand;
    public bool isPickWeapon { get; private set; }
    private void Awake()
    {
        weaponHand = FindObjectOfType<WeaponHand>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            isPickWeapon = RaycastHitItem();
            if (isPickWeapon) return;
            RayPickUpItem();
        }
    }
    private void RayPickUpItem()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, rayLengs, layerItem))
        {
            PickUpItem currentPick = hit.collider.GetComponent<PickUpItem>();
            currentPick.Interact();
            Debug.Log("hit");
        }
    }
    public void Shouting(float damage)
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, rayLengs, layerEnemy))
        {
            HpEnemy enemy = hit.collider.GetComponent<HpEnemy>();
            enemy.TakeDamage(damage);
        }
    }
    public bool RaycastHitItem()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, rayLengs, layerItem))
        {
            PickUpItem pick = hit.collider.transform.GetComponent<PickUpItem>();
            bool isWeapon = pick.PickWeapon();
            if (isWeapon)
            {
                weaponHand.SetWeaponHand(hit.collider.gameObject);
                // Исправить чтобы weaponHand возвращал bool-евый результат
                return true;
            }
            else return false;
        }
        else return false;
    }
}
