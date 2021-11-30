using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Butterfly.Instance.SayHello("one");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
