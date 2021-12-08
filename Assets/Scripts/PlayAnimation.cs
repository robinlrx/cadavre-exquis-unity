using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    private TranslationAnimation animation;
    // Start is called before the first frame update
    void Start()
    {
        SceneController.Instance.OnCloseScene += PlayAnimationController;
    }

    private void PlayAnimationController(string scene)
    {
        if (scene.CompareTo("Noise") == 0)
        {
            // animation.play();
        }
    }
}
