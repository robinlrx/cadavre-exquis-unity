using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
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
}
