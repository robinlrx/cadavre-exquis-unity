using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationAnimation : MonoBehaviour
{

    public Transform StartPoint;
    public Transform EndPoint;
    public float Duration;
    public float Randomness = 1f;

    public float Frequency = 1f;

    public int Seed = 40;

    private bool _isStarted = false;

    private bool _isPlay = false;
    
    void Start()
    {
        transform.position = StartPoint.transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !_isPlay){
            StartAnimation();
        }
    }

    public void StartAnimation(){
        _isStarted = true;
        gameObject.GetComponent<CameraFollow>().StartFollow();
        Debug.Log("start anim " + Time.time);
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        float time = 0f;
        float progress = 0f;
        Vector3 pos = new Vector3();
        while(time <= Duration){
            time += Time.deltaTime;
            progress = time/Duration;
            progress = EaseOutQuad(progress);

            pos = Vector3.Lerp(StartPoint.transform.position, EndPoint.transform.position, progress);
            pos = RandomizePosition(pos, time, (1.0f-progress));
            transform.position = pos;
            yield return null;
        }

        transform.position = EndPoint.transform.position;
        gameObject.GetComponent<CameraFollow>().StopFollow();
        _isPlay = true;
        Debug.Log("end anim " + Time.time);
    }

    private Vector3 RandomizePosition(Vector3 pos, float time, float progress){
        time = Seed + time * Frequency;
        float random = (Mathf.Sin(time) + Mathf.Sin(2.2f*time+5.52f) + Mathf.Sin(2.9f*time+0.93f) + Mathf.Sin(4.6f*time+8.94f)) / 4f;
        random *= Randomness;
        random *= progress;
        Vector3 r = new Vector3(random, random, 0f);
        return pos + r;
    }

    private float EaseOutQuart(float x) {
        return 1.0f - Mathf.Pow(1.0f - x, 4f);
    }

    //return 1 - (1 - x) * (1 - x);
    private float EaseOutQuad(float x) {
        return 1.0f - (1.0f - x) * (1.0f - x);
    }
}
