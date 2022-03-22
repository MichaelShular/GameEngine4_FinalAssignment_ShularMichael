using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState : States
{
    // Start is called before the first frame update
    protected ZombieComponent ownerZombie;

    public ZombieState(ZombieComponent zombie, ZombieStateMachine stateMachine) : base (stateMachine)
    {
        ownerZombie = zombie;
    }
        

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ZombieStateType
{
    Idling,
    Attack,
    Following,
    Dying
}
