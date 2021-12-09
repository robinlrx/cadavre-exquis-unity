using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public CanvasGroup Ui;
    VideoPlayer videoSource;

    // Start is called before the first frame update
    void Start()
    {
        videoSource = GetComponent<VideoPlayer>();
        SceneController.Instance.OnCloseScene += PlayVideoController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy(){
        SceneController.Instance.OnCloseScene -= PlayVideoController;
    }
    private IEnumerator SupTuto()
    {
        yield return new WaitForSeconds(3f);
        float time = 0f;
        float progress = 0f;
        float Duration = 3f;
        while(time <= Duration){
            time += Time.deltaTime;
            progress = time/Duration;
            Debug.Log(Ui);
            Ui.alpha = 1f - progress;
            yield return null;
        }
    }

    void PlayVideoController (string scene)
    {
        if (scene.CompareTo("Noise") == 0)
        {
            if(videoSource == null) videoSource = GetComponent<VideoPlayer>();
            videoSource.Play();
            StartCoroutine(SupTuto());
        }
    }
}
