using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField] State startingState;
    public State currentState { get; private set; }

    [SerializeField] List<NameStatePair> states = new List<NameStatePair>();

    private void Start()
    {
        Initialize();
        foreach (var state in states)
        {
            state.state.bind(this);
        }
    }

    public virtual void Initialize()
    {
        currentState = startingState;
        currentState.OnStateEnter();
    }

    public virtual void SwitchState(string stateName)
    {
        foreach (var state in states)
        {
            if (state.name==stateName)
            {
                currentState.OnStateExit();
                currentState = state.state;
                currentState.OnStateEnter();
                return;
            }
        }

        Debug.LogWarning("No state named " + stateName);
    }

    private void Update()
    {
        currentState.Tick(Time.deltaTime);
    }
    private void FixedUpdate()
    {
        currentState.FixedTick(Time.fixedDeltaTime);
    }
}

[System.Serializable]
public struct NameStatePair
{
    public string name;
    public State state;
}
