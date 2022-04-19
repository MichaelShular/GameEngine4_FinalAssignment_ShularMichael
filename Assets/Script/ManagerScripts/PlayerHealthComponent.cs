using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthComponent : HealthComponent
{

    public GameStateController gameStateController;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        gameStateController = GameObject.Find("GameManager").GetComponent<GameStateController>();
        PlayerEvents.InvokeOnHealthInitialized(this);
    }

    public override void Destory()
    {
        gameStateController.gameOver(false);

    }

}
