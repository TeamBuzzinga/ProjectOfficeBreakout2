/*
Team Buzzinga

Author: Dingfeng Shao

Member: Aaron Quek; David Chang; Ryan Anderson;	Siddharth
*/
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class DS_lights : MonoBehaviour {
	Light _light;
	AudioSource _audio;
	float _time=0;
	float wait=3;
	public Material sbox;
	// Use this for initialization
	void Start () {
		_light = GetComponent<Light> ();
		_audio = GetComponent<AudioSource> ();
		RenderSettings.ambientIntensity = 0.024f;
		RenderSettings.reflectionIntensity = 0.024f;
		_audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_time>wait) {
			if (Random.value > 0.9) {
				if (_light.enabled)
					_light.enabled = false;
				else
					_light.enabled = true;
			}
		}
		else
			_time += Time.deltaTime;
	}
}
