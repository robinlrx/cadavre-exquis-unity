using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
	AudioSource audioSource;
	public AudioClip otherClip; // variable to define in Unity inspector
	private Scene scene;
	private float scale;
	private bool isNewAudioSourceAdded;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		scene = SceneManager.GetActiveScene();
		scale = 0.1f;
	}

	void Update()
	{
		// add glass sound
		// if (scene.name == "Three") { // replace by One
		// 	audioSource.volume += Input.mouseScrollDelta.y * scale;
		// 	if (audioSource.volume == 1 && !isNewAudioSourceAdded) {
		// 		AudioSource audioSourceGlass = gameObject.AddComponent<AudioSource>();
		// 		audioSourceGlass.clip = otherClip;
		// 		audioSourceGlass.Play();
		// 		isNewAudioSourceAdded = true;
		// 	}
		// }

		// mute volume at scene Two
		if (scene.name == "Two") {
			if (Input.GetKeyDown(KeyCode.M)) {
				// change AudioClip;
				audioSource.clip = otherClip;
				audioSource.Play();
			}
		}

		// change volume at scene Three
		if (scene.name == "Three") {
			audioSource.volume += Input.mouseScrollDelta.y * scale;
		}

	}
}
