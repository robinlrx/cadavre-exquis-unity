using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneController.Instance.OnOpenScene += OnOpenScene;
    }

    private void OnOpenScene(string scene)
    {
        if (scene.CompareTo("One") == 0 ) {
            transform.DOMoveZ(5, 2);
            transform.DOMoveY(3, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
