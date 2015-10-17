using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {
    public State[] validStates;//This may or may not be used in later implementation
    State currentState;

    public enum StateType { IDLE, SUSPICIOUS, ALERT };


    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        currentState.updateState(Time.deltaTime);
    }

    public void changeState(StateType state)
    {
        State newState = null;   
            switch (state)
            {
            case StateType.IDLE:
                
                break;

            case StateType.SUSPICIOUS:
                break;

            case StateType.ALERT:
                break;
            default:
                return;
            }
        }
}
