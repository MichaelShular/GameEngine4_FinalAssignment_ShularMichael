using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieProtectState : ZombieState
{
    GameObject followTarget;
    GameObject protectTarget;

    int movementZHash = Animator.StringToHash("MovementZ");
    float startAttackDistance = 20;

    public ZombieProtectState(GameObject _followTarget, GameObject _portectTarget, ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
        followTarget = _followTarget;
        protectTarget = _portectTarget;
        UpdateInterval = 2;
    }

    public override void Start()
    {
        //base.Start();
        ownerZombie.zombieNavMeshAgent.SetDestination(protectTarget.transform.position);
    }

    public override void IntervalUpdate()
    {
        //base.IntervalUpdate();
        ownerZombie.zombieNavMeshAgent.SetDestination(protectTarget.transform.position);

    }

    public override void Update()
    {
        //base.Update();
        float moveZ = ownerZombie.zombieNavMeshAgent.velocity.normalized.z != 0 ? 1f : 0f;
        ownerZombie.zombieAnimator.SetFloat(movementZHash, moveZ);

        float distanceBetween = Vector3.Distance(ownerZombie.transform.position, followTarget.transform.position);

        if (distanceBetween < startAttackDistance)
        {
            stateMachine.ChangeState(ZombieStateType.Following);
        }

    }
}
