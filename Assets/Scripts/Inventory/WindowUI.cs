using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUI : MonoBehaviour
{
    public GameObject inventory;
    private bool isActive = true;
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDisable()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            InventoryActive();
        }
    }
    private void InventoryActive()
    {
        isActive = !isActive;
        inventory.SetActive(isActive);
    }
}
