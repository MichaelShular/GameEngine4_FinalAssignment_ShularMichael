using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon", order = 2)]


public class WeaponScriptable : EquippableScript
{

    public WeaponStats weaponStats;
    public override void UseItem(PlayerController playerController)
    {
        if (equipped)
        {
            playerController.weaponHolder.UnEquipWeapon();
        }
        else
        {
            playerController.weaponHolder.EquipWeapon(this);
            
        }

        base.UseItem(playerController);
    }

}
