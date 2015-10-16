using UnityEngine;
using System.Collections;

public abstract class State {

    public abstract void updateState(float deltaTime);
    public abstract void enterState();
    public abstract void exitState();

}
