using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    private Transform CameraTransform;
    private Vector3 InitPosition;
    public float Distance;
    private bool _followPapillon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraTransform == null) return;
        if(_followPapillon)
        CameraTransform.LookAt(transform);
    }

    public void StartFollow () {
        _followPapillon = true;
        CameraTransform = Camera.main.gameObject.transform;
        InitPosition = new Vector3(CameraTransform.position.x, CameraTransform.position.y, CameraTransform.position.z);
        CameraTransform.parent = transform;
        CameraTransform.localPosition = Vector3.zero;
        Vector3 Position = CameraTransform.localPosition;
        Position.z = Distance;
        Position.y = 5f;
        CameraTransform.localPosition = Position;
    }

    public void StopFollow () {
        _followPapillon = false;
        CameraTransform.parent = null;
        CameraTransform.DOLookAt(GameObject.Find("tv").transform.position, 1);
        CameraTransform.DOMoveZ(10, 2);
        CameraTransform.DOMoveY(5, 2);
        GetComponent<PapillonAnimation>().isRotatingAroundTV=true;
        
        // Revient à la position inititial de la camera soit z = 58
        // CameraTransform.position = InitPosition;
    }
}
