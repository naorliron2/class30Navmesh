using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected FiniteStateMachine FSM;
    public void bind(FiniteStateMachine FSM)
    {
        this.FSM = FSM;
    }
    
    /// <summary>
    /// Tick is what happens when the state is running;
    /// </summary>
    /// <param name="deltaTime"></param>
    public abstract void Tick(float deltaTime);
    
    /// <summary>
    /// Fixed tick is what happens when you need to run tick in fixed update;
    /// </summary>
    /// <param name="deltaTime"></param>
    public abstract void FixedTick(float deltaTime);

    /// <summary>
    /// Happens when we enter the space
    /// </summary>
    public virtual void OnStateEnter() { }
    
    /// <summary>
    /// happens when we leave the state
    /// </summary>
    public virtual void OnStateExit() { }
}
