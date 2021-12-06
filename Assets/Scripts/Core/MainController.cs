using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainController : MonoBehaviour
{
    private Transform CameraTransform;
    public enum State
    {
        SceneOne,
        SceneTwo,
        SceneThree
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneController.Instance.OpenScene("Accueil");
        SceneController.Instance.OpenScene("Intro");
        SceneController.Instance.OpenScene("TV");
        // SceneController.Instance.OpenScene("One");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneController.Instance.OpenScene("One");
            SceneController.Instance.CloseScene("Intro");
			SceneController.Instance.CloseScene("TV");
        }
    }

    public void ChangeScene (State state) {
        switch (state)
        {
            case State.SceneOne:
            CameraTransform.DOMoveZ(5, 2);
            CameraTransform.DOMoveY(3, 2); 
            SceneController.Instance.CloseScene("Intro");
            SceneController.Instance.OpenScene("One");
            SceneController.Instance.CloseScene("TV");
            break;
        }
    }
}
