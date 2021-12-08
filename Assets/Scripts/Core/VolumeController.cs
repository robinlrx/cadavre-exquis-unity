using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
	AudioSource audioSource;
	public AudioClip otherClip; // variable to define in Unity inspector
	private float scale;
	private bool isNewAudioSourceAdded;
	private string scene;

	private GameObject mainController;

	private MainController controller;

	void Start()
	{
		mainController = GameObject.Find("MainController");
		controller = mainController.GetComponent<MainController>();
		audioSource = GetComponent<AudioSource>();
		scale = 0.1f;
		scene = SceneController.Instance.GetActualScene();
	}

	void Update() {

		// add glass sound at scene One
		if(scene == "One") {
			audioSource.volume += Input.mouseScrollDelta.y * scale;

			if (audioSource.volume == 1 && !isNewAudioSourceAdded) {
				AudioSource audioSourceGlass = gameObject.AddComponent<AudioSource>();
				audioSourceGlass.clip = otherClip;
				audioSourceGlass.Play();
				isNewAudioSourceAdded = true;

        		controller.ChangeScene(MainController.State.SceneTwo);
			}
		}

		// mute volume at scene Two
		if (scene == "Two") {
			if (Input.GetKeyDown(KeyCode.M)) {
				// change AudioClip;
				audioSource.clip = otherClip;
				audioSource.Play();

        		controller.ChangeScene(MainController.State.SceneThree);
			}
		}

		// change volume at scene Three
		if (scene == "Three") {
			audioSource.volume += Input.mouseScrollDelta.y * scale;
		}
	}
}
