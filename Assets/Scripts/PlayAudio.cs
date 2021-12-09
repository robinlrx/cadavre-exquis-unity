using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Play Audio Start : " + audioSource + " " + gameObject.name);
        SceneController.Instance.OnCloseScene += PlayAudioController;
    }

    void PlayAudioController (string scene)
    {
        Debug.Log("audio");
        if (scene.CompareTo("Noise") == 0)
        {
            Debug.Log("if audio");
            if(audioSource == null) audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }

    void OnDestroy(){
        SceneController.Instance.OnCloseScene -= PlayAudioController;
    }
}
