using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuickTrigger : MonoBehaviour {
    public float explosionForce;
    public float explosionRadius;
    public AudioClip clip;

    List<Rigidbody> explosionStuff;

    void Start()
    {
        explosionStuff = new List<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider)
    {
        Rigidbody rigid = collider.GetComponent<Rigidbody>();
        if (rigid != null)
        {
            explosionStuff.Add(rigid);
        }


    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "Player")
        {
            explode();
        }
    }

    void explode()
    {
        AudioSource.PlayClipAtPoint(clip, this.transform.position);

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
