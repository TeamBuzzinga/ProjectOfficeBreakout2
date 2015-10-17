using UnityEngine;
using System.Collections;

public class CannonLogic : MonoBehaviour {
    public Transform cannonBall;
    public float force;
    public Transform cannonFireLocation;
    public Transform cannonDirection;

    bool isActive;
    Transform target;
    float cannonTimer;
    AudioSource aSource;

    void Start()
    {
        resetCannonTimer();
        aSource = GetComponent<AudioSource>();
    }

    public void setIsActive(bool isActive)
    {
        this.isActive = isActive;
    }

    public void setTargetTransform(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (isActive)
        {
            adjustCannonRotation();
            checkFire();
        }
    }

    void adjustCannonRotation()
    {
        Vector3 offset = target.position - this.transform.position;
        offset = new Vector3(offset.x, 0, offset.z).normalized;
        float rotation = Mathf.Atan2(offset.z, -offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, rotation, 0), Time.deltaTime * 8);
    }

    void checkFire()
    {
        cannonTimer -= Time.deltaTime;
        if (cannonTimer < 0f)
        {
            fireCannon();
            resetCannonTimer();
        }
    }

    void resetCannonTimer()
    {
        cannonTimer = Random.Range(1f, 5f);
    }

    void fireCannon()
    {
        aSource.Stop();
        aSource.pitch = Random.Range(.8f, 1.2f);
        aSource.Play();
        GameObject obj = (GameObject)Instantiate(cannonBall.gameObject, cannonFireLocation.position, new Quaternion());
        obj.GetComponent<Rigidbody>().AddForce(cannonDirection.up * force);
    }
}
