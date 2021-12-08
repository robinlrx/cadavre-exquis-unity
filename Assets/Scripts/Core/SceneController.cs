using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public delegate void SceneControllerEvent(string scene);
    public event SceneControllerEvent OnOpenScene;
    public event SceneControllerEvent OnCloseScene;

    public void OpenScene(string scene, bool preload = false, LoadSceneMode mode = LoadSceneMode.Additive){

        if(preload) {
            StartCoroutine(OpenSceneAsync(scene, mode));
        } else {
            SceneManager.LoadSceneAsync(scene, mode);
            OnOpenScene?.Invoke(scene);
        }
    }

    private IEnumerator OpenSceneAsync(string scene, LoadSceneMode mode)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene, mode);
        operation.allowSceneActivation = false;
        while (!operation.isDone) {
            if (operation.progress >= 0.9f) {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
        OnOpenScene?.Invoke(scene);
    }

    public void CloseScene(string scene) {
        SceneManager.UnloadSceneAsync(scene);
        OnCloseScene?.Invoke(scene);
    }
} 
