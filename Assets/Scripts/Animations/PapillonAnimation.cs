using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapillonAnimation : MonoBehaviour
{
    public bool isRotatingAroundTV = false;
    public bool isTranslating = false;
	private GameObject Tv;

	public int _Altitude;
    public int Duration;
    public int Speed;
	private float _angle;

	public Transform Center;
	public float Radius;

    private float _timeRotate = 0;
    private float _startTranslateTime = 0;

    private Vector3 _initTranslatePosition;
    public float TranslationDuration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 public void SetRotate(){
     Debug.Log("SetRotate");
     StartCoroutine(PreTransition());
 }
    // Update is called once per frame
    void Update()
    {
        if (isRotatingAroundTV) {
            _timeRotate+=Time.deltaTime;
            RotateAroundTV();
            if(_timeRotate>= Duration){
                SetTranslate();
            }
        }else if (isTranslating){
            Translate();
        }
    }

    private void SetTranslate()
    {
        isRotatingAroundTV = false;
        isTranslating = true;

        _startTranslateTime = Time.time;

        _initTranslatePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    private void RotateAroundTV(){
        // transform.RotateAround(Center.position,new Vector3(sin(), 0.1f, 0), 30 * Time.deltaTime);

		_angle += Speed*Time.deltaTime;
        transform.position = new Vector3(Center.position.x + Mathf.Sin(_angle)*Radius, _Altitude, Center.position.z + Mathf.Cos(_angle)*Radius);
    }

    private void Translate()
    {
        float progress = Time.time-_startTranslateTime/TranslationDuration;
        progress= Mathf.Max(0, Mathf.Min(progress, 1));
        transform.position = Vector3.Lerp(_initTranslatePosition, Center.position, progress);
    }

    private IEnumerator PreTransition () {
        float time = 0;
        float progress = 0;
        float duration = 3f;
        Vector3 InitPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 DestPosition = new Vector3(Center.position.x + Mathf.Sin(0)*Radius, _Altitude, Center.position.z + Mathf.Cos(0)*Radius);
        Debug.Log(InitPosition);

        while (time <= duration) {
            progress = time/duration;
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(InitPosition, DestPosition, progress);
            Debug.Log("PreTransition");
            Debug.Log(Radius + " " +  DestPosition + " " + InitPosition);
            yield return null;
        }

        transform.position = DestPosition;
        isRotatingAroundTV = true;
        _timeRotate = 0;
        Debug.Log("Fin PreTransition");
        Debug.Log(Radius + " " +  DestPosition + " " + InitPosition);
    }

}
