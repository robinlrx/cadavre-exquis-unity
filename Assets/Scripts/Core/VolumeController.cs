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
		scale = 0.05f;
		scene = SceneController.Instance.GetActualScene();
	}

	void Update() {

		// control volume at scene
		if(scene == "One" || scene == "Two" || scene == "Three") {
			audioSource.volume += Input.mouseScrollDelta.y * scale;

			if (scene == "One" && audioSource.volume == 1 && !isNewAudioSourceAdded) {
				AudioSource audioSourceGlass = gameObject.AddComponent<AudioSource>();
				audioSourceGlass.clip = otherClip;
				audioSourceGlass.Play();
				isNewAudioSourceAdded = true;

				StartCoroutine(NextScene(MainController.State.SceneTwo));
			}

			if (scene == "Three" && audioSource.volume == 0) {
				StartCoroutine(NextScene(MainController.State.SceneEnd));
			}
		}

		// mute volume at scene 
		if (scene == "One" || scene == "Two" || scene == "Three") {
			if (Input.GetKeyDown(KeyCode.M)) {
				if(scene != "Two") {
				audioSource.mute = !audioSource.mute;
				}

				// change AudioClip;
				if (scene == "Two") {
				audioSource.clip = otherClip;
				audioSource.Play();

				StartCoroutine(NextScene(MainController.State.SceneThree));
					

				}
			}
		}
	}

	 private IEnumerator NextScene(MainController.State state)
    {
        yield return new WaitForSeconds(2f);
        controller.ChangeScene(state);
    }
}
