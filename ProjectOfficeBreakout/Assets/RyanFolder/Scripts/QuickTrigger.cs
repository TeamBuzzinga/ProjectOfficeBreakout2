using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuickTrigger : MonoBehaviour {
    public float explosionForce;
    public float explosionRadius;

    List<Rigidbody> explosionStuff;

    void Start()
    {
        explosionStuff = new List<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider)
    {
        Rigidbody rigid = collider.GetComponent<Rigidbody>();
        if (collider.tag == "Player")
        {
            //explosionStuff.Add(collider.GetComponent<Rigidbody>());
            //collider.GetComponent<Animator>().enabled = false;
            explode();
        }
        else if (rigid != null)
        {
            explosionStuff.Add(rigid);
        }


    }

    void explode()
    {
        foreach(Rigidbody rigid in explosionStuff)
        {
            rigid.AddExplosionForce(explosionForce, this.transform.position, explosionRadius);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        Rigidbody rigid = collider.GetComponent<Rigidbody>();
        if (rigid != null && explosionStuff.Contains(rigid)) {
            explosionStuff.Remove(rigid);
        }
    }
}
