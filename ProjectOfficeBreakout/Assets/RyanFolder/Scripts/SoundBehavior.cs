using UnityEngine;
using System.Collections;

public class SoundBehavior : MonoBehaviour {
    public float timeActive;
    public float intensity;

    private float activeTimer;

	// Use this for initialization
	void Start () {
        this.tag = "SoundBehavior";
        activeTimer = timeActive;
	}
	
	// Update is called once per frame
	void Update () {
        activeTimer -= Time.deltaTime;
        checkDestroyObject();
	}

    void checkDestroyObject()
    {
        if (activeTimer < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter()
    {

    }
}
