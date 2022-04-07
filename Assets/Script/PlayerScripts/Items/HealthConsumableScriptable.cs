using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Item/HealthPotion", order = 2)]

public class HealthConsumableScriptable : ConsumableScriptable
{
    public override void UseItem(PlayerController playerController)
    {
        if (playerController.healthComponent.CurrentHealth >= playerController.healthComponent.MaxHealth) return;

        playerController.healthComponent.HealPlayer(effect); 

        base.UseItem(playerController);
    }
}
