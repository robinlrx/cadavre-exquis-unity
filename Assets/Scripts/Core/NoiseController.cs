using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneController.Instance.OnOpenScene += OnOpenScene;
    }
    private void OnOpenScene(string scene)
    {
        StartCoroutine(CloseNoise());
    }
    private IEnumerator CloseNoise()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Noise");
        SceneController.Instance.OnOpenScene -= OnOpenScene;
        SceneController.Instance.CloseScene("Noise");
    }
    void OnDestroy()
    {
        SceneController.Instance.OnOpenScene -= OnOpenScene;
    }
}
