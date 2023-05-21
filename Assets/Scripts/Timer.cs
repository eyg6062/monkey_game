using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private float timer = 0;
    private bool timerOn = false;
    private float offset = 0;
    private bool isOffset = true;

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timer += Time.deltaTime * 1000;

            if (isOffset)
            {
                if (timer >= 0)
                {
                    isOffset = false;
                }
            }

            //Debug.Log(timer);
            
        }
        
    }

    public void SetUpTimer(float offset)
    {
        this.offset = offset;
        timer -= offset;
    }


    public void StopTimer()
    {
        timerOn = false;
    }

    public void StartTimer()
    {
        timerOn = true;
    }

    public void ResetTimer()
    {
        timer = 0;
        isOffset = false;
    }

    public float GetTimer()
    {
        return timer;
    }

    public bool IsOffset()
    {
        return isOffset;
    }
}
