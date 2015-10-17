using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour {
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "CannonBall")
        {
            anim.enabled = false;
        }
    }
}
