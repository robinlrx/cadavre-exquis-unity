using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform CameraTransform;
    private Vector3 InitPosition;
    public float Distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraTransform == null) return;
        CameraTransform.LookAt(transform);
    }

    public void StartFollow () {
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
        CameraTransform.parent = null;
        // Revient à la position inititial de la camera soit z = 58
        // CameraTransform.position = InitPosition;
    }
}
