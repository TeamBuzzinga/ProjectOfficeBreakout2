using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {
    public AudioClip grassSound;
    public AudioClip stoneSound;
    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.loop = false;
        aSource.Stop();
    }

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.tag == "Grass")
        {
            aSource.Stop();
            aSource.pitch = Random.Range(.5f, 1.5f);
            aSource.volume = Random.Range(.3f, .5f);
            aSource.clip = grassSound;
            aSource.Play();
        }
        if (collider.tag == "Stone")
        {
            aSource.Stop();
            aSource.pitch = Random.Range(.5f, 1.5f);
            aSource.volume = Random.Range(.3f, .5f);
            aSource.clip = stoneSound;
            aSource.Play();
        }
        
    }
}
