using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    AudioSource audioSource;
	public AudioClip oiseauwav; // variable to define in Unity inspector

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
		// mute volume
        if (Input.GetKeyDown(KeyCode.M)) {
            // change AudioClip;
			audioSource.clip=oiseauwav;
			audioSource.Play();
		}
    }
}
