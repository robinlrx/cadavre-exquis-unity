using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvIntersect : MonoBehaviour
{
    public float delay;

    void OnTriggerEnter (Collider other) {
        if (other.name.CompareTo("Papillon") == 0 ) {
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(delay);
        GameObject mainController = GameObject.Find("MainController");
        MainController controller = mainController.GetComponent<MainController>();
        controller.ChangeScene(MainController.State.SceneOne);
    }
}
