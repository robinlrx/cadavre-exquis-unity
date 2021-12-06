using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvIntersect : MonoBehaviour
{
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other) {
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
