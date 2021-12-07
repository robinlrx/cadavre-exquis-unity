using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvIntersect : MonoBehaviour
{
    public float delay;

    void OnTriggerEnter (Collider other) {
        Debug.Log("On trigger enter : " + other.name);
        if (other.name.CompareTo("Papillon") == 0 ) {
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(delay);
        GameObject.Find("MainController").GetComponent<MainController>();
        throw new NotImplementedException();
    }
}
