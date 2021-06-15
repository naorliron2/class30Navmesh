using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChaseState : State
{
    [SerializeField] float distanceToStop;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;
    [SerializeField] LayerMask playerLayermask;

    public override void FixedTick(float deltaTime)
    {
    }

    public override void Tick(float deltaTime)
    {
        navMeshAgent.SetDestination(player.position);

        if (!Physics.CheckSphere(transform.position, distanceToStop, playerLayermask))
        {
            FSM.SwitchState("Idle");
        }
    }

    public override void OnStateExit()
    {
        navMeshAgent.SetDestination(transform.position);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanceToStop);
    }

}
