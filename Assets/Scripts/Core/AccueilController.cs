using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AccueilController : MonoBehaviour
{
    public AudioSource TvSound;
    public CanvasGroup Ui;

    
    public void StartGame ()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade() {
        float time = 0f;
        float progress = 0f;
        float Duration = 2f;
        while(time <= Duration){
            time += Time.deltaTime;
            progress = time/Duration;
            TvSound.volume = 0.05f - progress;
            Ui.alpha = 1f - progress;
            yield return null;
        }
        SceneController.Instance.CloseScene("Accueil");
        GameObject.Find("Video Player Docu").GetComponent<VideoPlayer>().Play();
    }
}
