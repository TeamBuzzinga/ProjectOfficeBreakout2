using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public string[] sceneNames;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        int index = -1;
	    if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("I Was Here");
            index = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            index = 4;
        }

        if (index >= 0 && index < sceneNames.Length)
        {
            Application.LoadLevel(sceneNames[index]);
        }
	}
}
