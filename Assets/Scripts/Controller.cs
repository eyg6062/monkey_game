using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private bool closed = false;
    private SoundManager soundManager;
    private SongManager songManager;

    private void Awake()
    {
        soundManager = gameObject.GetComponent<SoundManager>();

        songManager = gameObject.GetComponent<SongManager>();
    }

    private void Update()
    {
        // check if c is held
        if (Input.GetKey(KeyCode.C))
        {
            closed = true;
        } 
        else
        {
            closed = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {

            songManager.CheckNote(closed);
            soundManager.PlayCuica(closed, 0);

        }
    }
}
