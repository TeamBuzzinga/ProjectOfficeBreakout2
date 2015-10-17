using UnityEngine;
using System.Collections;

public class CannonBallLogic : MonoBehaviour {
    float timeActive = 10;
    float coolDown = .2f;
    bool coolDownActive;
    void Update()
    {
        timeActive -= Time.deltaTime;
        if (timeActive < 0)
        {
            Destroy(this.gameObject);
        }
        if (coolDownActive)
        {
            coolDown -= Time.deltaTime;
        }
        if (coolDown < 0)
        {
            this.tag = "Untagged";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        coolDownActive = true;   
    }
}
