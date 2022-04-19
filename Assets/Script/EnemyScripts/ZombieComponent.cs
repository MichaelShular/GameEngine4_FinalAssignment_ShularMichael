using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieComponent : MonoBehaviour
{
    public int zombieDamage = 5;

    public NavMeshAgent zombieNavMeshAgent;
    public Animator zombieAnimator;
    public ZombieStateMachine zombieStateMachine;
    public GameObject followTarget;
    public GameObject spawn;


    private void Awake()
    {
        zombieNavMeshAgent = GetComponent<NavMeshAgent>();
        zombieAnimator = GetComponentInChildren<Animator>();
        zombieStateMachine = GetComponent<ZombieStateMachine>();
        
        //Initialize(followTarget, spawn);
    }

    public void Start()
    {
        
    }

    public void Initialize(GameObject _followTarget, GameObject _Spawn)
    {
        followTarget = _followTarget;
        spawn = _Spawn;

        ZombieIdleState idleState = new ZombieIdleState(this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.Idling, idleState);

        ZombieFollowState followState = new ZombieFollowState(followTarget ,this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.Following, followState);

        ZombieAttackState attackState = new ZombieAttackState(followTarget, this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.Attack, attackState);
        
        ZombieDyingState deadState = new ZombieDyingState(this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.Dying, deadState);

        ZombieProtectState protectState = new ZombieProtectState(followTarget, spawn, this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.Protecting, protectState);

        zombieStateMachine.Initialize(ZombieStateType.Protecting);
    }
}
