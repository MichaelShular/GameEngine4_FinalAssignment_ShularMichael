using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalHealthComponent : HealthComponent
{
    public GameStateController gameStateController;
    protected override void Start()
    {
        base.Start();
        gameStateController = GameObject.Find("GameManager").GetComponent<GameStateController>();
        PlayerEvents.InvokeOnHealthInitialized(this);
    }

    public override void Destory()
    {
        gameStateController.removeOneCrystal();
        Destroy(this.gameObject);
    }
}
