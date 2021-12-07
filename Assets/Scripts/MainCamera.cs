using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainCamera : Singleton<MainCamera>
{
    private Transform CameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SceneController (Collider state) {
        if (state.name.CompareTo("SceneOne") == 0 ) {
            CameraTransform.DOMoveZ(5, 2);
            CameraTransform.DOMoveY(3, 2);
        }
    }
}
