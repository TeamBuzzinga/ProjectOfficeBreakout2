using UnityEngine;
using System.Collections;

public class CannonBallLogic : MonoBehaviour {
    float timeActive;
    void Update()
    {
        timeActive += Time.deltaTime;
    }

    void OnCollisionEnter()
    {
        if (timeActive > .2f)
        this.tag = "Untagged";
    }
}
