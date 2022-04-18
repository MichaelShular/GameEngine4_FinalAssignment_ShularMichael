using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowState : ZombieState
{
    GameObject followTarget;
    float stoppingDistance = 1;

    int movementZHash = Animator.StringToHash("MovementZ");

    public ZombieFollowState(GameObject _followTarget, ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
        followTarget = _followTarget;
        UpdateInterval = 2;
    }

    public override void Start()
    {
        base.Start();
        ownerZombie.zombieNavMeshAgent.SetDestination(followTarget.transform.position);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        ownerZombie.zombieNavMeshAgent.SetDestination(followTarget.transform.position);

    }

    public override void Update()
    {
        base.Update();
        float moveZ = ownerZombie.zombieNavMeshAgent.velocity.normalized.z != 0 ? 1f: 0f;
        ownerZombie.zombieAnimator.SetFloat(movementZHash, moveZ);

        float distanceBetween = Vector3.Distance(ownerZombie.transform.position, followTarget.transform.position);
        if (distanceBetween > 20)
        {
            stateMachine.ChangeState(ZombieStateType.Protecting);
        }
        if (distanceBetween < stoppingDistance)
        {
            stateMachine.ChangeState(ZombieStateType.Attack);
        }

        

    }

}
