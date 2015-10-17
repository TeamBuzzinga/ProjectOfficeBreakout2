using UnityEngine;
using System.Collections;

public class PlayerFollowNPC : MonoBehaviour {
    public float speed;
    bool followPlayer = true;
    Transform target;
    Rigidbody rigid;
    AudioSource aSource;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            target = collider.transform;
        }
    }

    void Update()
    {
        if (target != null && followPlayer)
        {
            Vector3 moveVector = target.transform.position - this.transform.position;
            moveVector = new Vector3(moveVector.x, 0, moveVector.z).normalized;
            rigid.velocity = Vector3.Lerp(rigid.velocity, moveVector * speed, Time.deltaTime * 4);

        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "Player")
        {
            aSource.Stop();
            aSource.pitch = Random.Range(.4f, 1.3f);
            aSource.Play();
            followPlayer = false;
            rigid.constraints = RigidbodyConstraints.None;
        }
    }
}
