using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private bool closed = false;
    private SoundManager soundManager;

    private void Awake()
    {
        gameObject.GetComponent<SoundManager>();
        soundManager = gameObject.GetComponent<SoundManager>();
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
            soundManager.PlayCuica(closed, 0);
        }
    }
}
