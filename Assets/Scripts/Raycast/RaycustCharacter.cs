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
            if (RayHitWeapon(hit, isWeapon)) return true;
            pick.Interact();
        }
        return false;
    }
    public bool RayHitWeapon(RaycastHit hit, bool isWeapon)
    {
        if (isWeapon)
        {
            return weaponHand.SetWeaponHand(hit.collider.gameObject);
        }
        else return false;
    }
}
