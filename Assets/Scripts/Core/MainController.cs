using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private Transform CameraTransform;
    public enum State
    {
        SceneOne,
        SceneTwo,
        SceneThree,
        SceneEnd
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneController.Instance.OpenScene("Accueil");
        SceneController.Instance.OpenScene("Intro");
        SceneController.Instance.OpenScene("TV");
    }

    public void ChangeScene (State state) {
        Debug.Log(state);
        switch (state)
        {
            case State.SceneOne:
            SceneController.Instance.OpenScene("Noise");
            SceneController.Instance.CloseScene("Intro");
            SceneController.Instance.CloseScene("TV");
            SceneController.Instance.OpenScene("One", true);
            break;

            case State.SceneTwo:
            SceneController.Instance.OpenScene("Noise");
            SceneController.Instance.CloseScene("One");
            SceneController.Instance.OpenScene("Two", true);
            break;

            case State.SceneThree:
            SceneController.Instance.OpenScene("Noise");
            SceneController.Instance.CloseScene("Two");
            SceneController.Instance.OpenScene("Three", true);
            break;

            case State.SceneEnd:
            SceneController.Instance.CloseScene("Three");
            SceneController.Instance.OpenScene("End");
            break;
        }
    }
}
