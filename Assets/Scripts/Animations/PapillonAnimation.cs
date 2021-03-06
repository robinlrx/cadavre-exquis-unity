using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapillonAnimation : MonoBehaviour
{
    private bool isRotatingAroundTV = false;
    private bool isTranslating = false;
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
		_angle += Speed*Time.deltaTime;
        transform.position = GetCirclePoint(_angle);
    }

    private void Translate()
    {
        float progress = Time.time-_startTranslateTime/TranslationDuration;
        progress= Mathf.Max(0, Mathf.Min(progress, 1));
        transform.position = Vector3.Lerp(_initTranslatePosition, Center.position, progress);
        if(progress == 1) {
            isTranslating = false;
        }
    }

    private IEnumerator PreTransition () {
        float time = 0;
        float progress = 0;
        float duration = 3f;
        Vector3 InitPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 DestPosition = GetCirclePoint(0);
        Debug.Log(InitPosition);

        while (time <= duration) {
            progress = time/duration;
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(InitPosition, DestPosition, progress);
            yield return null;
        }

        transform.localPosition  = DestPosition;
        isRotatingAroundTV = true;
        _timeRotate = 0;
    }

    private Vector3 GetCirclePoint(float angle){
        return new Vector3(Center.position.x + Mathf.Cos(angle)*Radius, _Altitude, Center.position.z - Mathf.Sin(angle)*Radius);
    }

}
