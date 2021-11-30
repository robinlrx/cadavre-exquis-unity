using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTwoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Butterfly.Instance.SayHello("two");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
