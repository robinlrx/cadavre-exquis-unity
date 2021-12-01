using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour
{

    public Transform CenterPoint;
    [SerializeField]
    public int Speed;
    public float Randomness = 10.0f;
    private bool Started = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Started) return;
        Vector3 target = new Vector3(GetXPosition(), GetYPosition(), 2f);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);
    }

    public void StartAnimation ()
    {
        Started = true;
    }

    float GetYPosition()
    {
        if (transform.position.z <= 2)
        {
            return 0f;
        }
        else
        {
            float x = Time.time;
            float y = (Mathf.Sin(x) + Mathf.Sin(2.2f * x + 5.52f) + Mathf.Sin(2.9f * x + 0.93f) + Mathf.Sin(4.6f * x + 8.94f));
            y = Mathf.Abs(y);
            return y * Randomness;
        }
    }

    float GetXPosition()
    {
        if (transform.position.z <= 2)
        {
            return 0f;
        }
        else
        {
            float x = Time.time;
            float y = (Mathf.Sin(x) + Mathf.Sin(2.2f * x + 5.52f) + Mathf.Sin(2.9f * x + 0.93f) + Mathf.Sin(4.6f * x + 8.94f));
            y = Mathf.Abs(y);
            return y * Randomness;
        }
    }
}
