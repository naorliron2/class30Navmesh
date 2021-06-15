using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In this state the enemy searches for a player;
public class IdleState : State
{
    [SerializeField]float searchRadius;
    [SerializeField] LayerMask playerLayermask;
    public override void FixedTick(float deltaTime)
    {
        //nothing needs fixedUpdate right now
    }

    public override void Tick(float deltaTime)
    {
        if (Physics.CheckSphere(transform.position, searchRadius, playerLayermask))
        {
            FSM.SwitchState("Chase");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }


}
