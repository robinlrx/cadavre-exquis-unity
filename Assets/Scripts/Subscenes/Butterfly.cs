using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : Singleton<Butterfly>
{
    public void SayHello(string fromScene){
        Debug.Log("Hello from " + fromScene);
    }
}
