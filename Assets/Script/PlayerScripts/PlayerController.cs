using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isFiring;
    public bool isReloading;
    public bool isJumping;
    public bool isRunning;
    public bool isAiming;

    public InventoryComponent inventory;
    public bool inInventory;
    public GameUIController uIController;
    public WeaponHolder weaponHolder;


    private void Awake()
    {
        inventory = GetComponent<InventoryComponent>();
        uIController = FindObjectOfType<GameUIController>();
        weaponHolder = GetComponent<WeaponHolder>();
    }
    public void OnInventory(InputValue value)
    {

        inInventory = !inInventory;
        OpenInventory(inInventory);
    }

    public void OpenInventory(bool open)
    {
        if (open)
        {
            uIController.EnableInventoryMenu();
        }
        else
        {
            uIController.EnableGameMenu();
        }
    }
}
