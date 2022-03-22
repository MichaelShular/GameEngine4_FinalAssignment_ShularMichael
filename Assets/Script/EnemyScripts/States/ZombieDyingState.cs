using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDyingState : ZombieState
{

    int movementZHash = Animator.StringToHash("MovementZ");
    int isDeadHash = Animator.StringToHash("IsDead");


    public ZombieDyingState(ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
        UpdateInterval = 0;
    }

    public override void Start()
    {
        ownerZombie.zombieNavMeshAgent.isStopped = true;
        ownerZombie.zombieNavMeshAgent.ResetPath();
        ownerZombie.zombieAnimator.SetFloat(movementZHash, 0);
        ownerZombie.zombieAnimator.SetBool(isDeadHash, true);
    }

    public override void Exit()
    {
        base.Exit();
        ownerZombie.zombieNavMeshAgent.isStopped = false;
        ownerZombie.zombieAnimator.SetBool(isDeadHash, false);

    }
}
