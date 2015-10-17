using UnityEngine;
using System.Collections;

public class CannonTrigger : MonoBehaviour {
    public CannonLogic[] allCannons;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            foreach(CannonLogic logic in allCannons)
            {
                logic.setIsActive(true);
                logic.setTargetTransform(collider.transform);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            foreach (CannonLogic logic in allCannons)
            {
                logic.setIsActive(false);
                logic.setTargetTransform(null);
            }
        }
    }
}
