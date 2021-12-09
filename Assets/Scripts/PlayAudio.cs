using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneController.Instance.OnCloseScene += PlayAudioController;
    }

    void PlayAudioController (string scene)
    {
        if (scene.CompareTo("Noise") == 0)
        {
            audioSource.Play();
        }
    }
}
