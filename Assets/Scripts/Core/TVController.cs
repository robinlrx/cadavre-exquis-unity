using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneController.Instance.OnOpenScene += OnSceneOpened;
        SceneController.Instance.OnCloseScene += OnSceneClosed;
    }

    private void OnSceneClosed(string scene)
    {
        Debug.Log("Scene "+ scene + " Closed");
    }

    private void OnSceneOpened(string scene)
    {
        Debug.Log("Scene "+ scene + " Opened");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
