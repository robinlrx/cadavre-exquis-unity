using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapillonAnimation : MonoBehaviour
{
    public bool isRotatingAroundTV;
	private GameObject Tv;

	private int _Altitude;
    public int Speed;
	private float _angle;

	public Transform Center;
	public float Radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotatingAroundTV) {
            RotateAroundTV();
        }
    }

    private void RotateAroundTV(){
        // transform.RotateAround(Center.position,new Vector3(sin(), 0.1f, 0), 30 * Time.deltaTime);

		_angle += Speed*Time.deltaTime;
        transform.position = new Vector3(Center.position.x + Mathf.Sin(_angle)*Radius, _Altitude, Center.position.z + Mathf.Cos(_angle)*Radius);
    }
}
