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
        if (collider.collider.tag == "Hazard")
        {
            anim.enabled = false;
            GetComponent<CapsuleCollider>().height = .5f;
        }
    }
}
