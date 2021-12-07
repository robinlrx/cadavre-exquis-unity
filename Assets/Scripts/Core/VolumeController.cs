using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
		// mute volume
        if (Input.GetKeyDown(KeyCode.M)) {
            audioSource.mute = !audioSource.mute;
		}
    }
}
