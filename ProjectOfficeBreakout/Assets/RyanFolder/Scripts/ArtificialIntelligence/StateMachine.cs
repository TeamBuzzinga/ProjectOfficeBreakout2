using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {
    public State[] validStates;
    State currentState;

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        currentState.updateState(Time.deltaTime);
    }

    public void changeState(State newState)
    {
        currentState.exitState();
        currentState = newState;
        currentState.enterState();
    }
}
