using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHand : MonoBehaviour
{
    private Transform weaponHand;
    private void Awake()
    {
        weaponHand = GetComponent<Transform>();
    }
    public bool SetWeaponHand(GameObject weapon)
    {
        if (weapon == null) return false;
        else
        {
            weapon.transform.SetParent(weaponHand);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
            weapon.transform.GetComponent<Rigidbody>().isKinematic = true;
            weapon.transform.GetComponent<Collider>().enabled = false;
            return true;
        }

    }
}
