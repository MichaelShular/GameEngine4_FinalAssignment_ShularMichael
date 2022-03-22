using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : ZombieState
{
    GameObject followTarget;
    float attackRange = 2;

    int movementZHash = Animator.StringToHash("MovementZ");
    int isAttacking = Animator.StringToHash("IsAttacking");


    public ZombieAttackState(GameObject _followTarget, ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
        followTarget = _followTarget;
        UpdateInterval = 2f;

        //Set damage interval
    }

    public override void Start()
    {
        //base.Start(_stateMachine);
        ownerZombie.zombieNavMeshAgent.isStopped = true;
        ownerZombie.zombieNavMeshAgent.ResetPath();
        ownerZombie.zombieAnimator.SetFloat(movementZHash, 0);
        ownerZombie.zombieAnimator.SetBool(isAttacking, true);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
    }

    public override void Update()
    {
        //base.Update();

        ownerZombie.transform.LookAt(followTarget.transform.position, Vector3.up);
        float distanceBetween = Vector3.Distance(ownerZombie.transform.position, followTarget.transform.position);
        if(distanceBetween > attackRange)
        {
            stateMachine.ChangeState(ZombieStateType.Following);
        }
    }

    public override void Exit()
    {
        base.Exit();
        ownerZombie.zombieNavMeshAgent.isStopped = false;
        ownerZombie.zombieAnimator.SetBool(isAttacking, false);

    }

}
