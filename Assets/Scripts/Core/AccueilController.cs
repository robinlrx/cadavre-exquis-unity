using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccueilController : MonoBehaviour
{
    public void StartGame ()
    {
        SceneController.Instance.CloseScene("Accueil");
    }
}
