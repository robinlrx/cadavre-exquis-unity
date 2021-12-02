using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    private TranslationAnimation animation;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Papillon = GameObject.Find("Papillon");
        animation = Papillon.GetComponent<TranslationAnimation>();
        SceneController.Instance.OnCloseScene += PlayAnimation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAnimation (string scene)
    {
        if (scene.CompareTo("Accueil") == 0)
        {
            animation.StartAnimation();
        }
    }
}
