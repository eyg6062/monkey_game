using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool timerOn = false;
    private float timer;
    private float offset;
    private bool isOffset = true;

    private float songLength;

    // canvas, lazy
    [SerializeField] GameObject canvasPf;


    private AudioSource song;

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timer = song.time * 1000;
        }
        timer = song.time * 1000;
        //timer += Time.deltaTime * 1000;

        if (isOffset)
        {
            if (timer >= offset)
            {
                ActivateTimer();
                isOffset = false;
            }
        }

        //Debug.Log(GetTimer());
        
        if (timer + 50 >= songLength-1)
        {
            // show score screen after song ends
            timer = songLength - 1;
            timerOn = false;
            GameObject.Find("big moke effect").SetActive(false);

            Instantiate(canvasPf);

        }
        

    }

    private void ActivateTimer()
    {
        timerOn = true;
    }

    public bool IsActivated()
    {
        return timerOn;
    }

    public void SetUpTimer(AudioSource song, float offset)
    {
        this.song = song;
        this.offset = offset;
        songLength = song.clip.length * 1000;
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa " + songLength);
    }

    public void ResetTimer()
    {
        timer = 0;
        isOffset = false;
    }

    public float GetTimer()
    {
        return timer - offset;
    }



    public bool IsOffset()
    {
        return isOffset;
    }
}
