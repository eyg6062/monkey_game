using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private bool closed = false;
    private SoundManager soundManager;
    private SongManager songManager;

    private GameObject bigMoke;
    private MonkeyAnimate animate;

    private KeyCode holdKey = KeyCode.C; 
    private KeyCode playKey = KeyCode.Z;

    private void Awake()
    {
        soundManager = gameObject.GetComponent<SoundManager>();

        songManager = gameObject.GetComponent<SongManager>();
    }

    private void Start()
    {
        bigMoke = GameObject.FindGameObjectWithTag("Big Moke");
        animate = bigMoke.GetComponent<MonkeyAnimate>();
    }

    private void Update()
    {
        // check if c is held
        if (Input.GetKey(holdKey))
        {
            closed = true;
        } 
        else
        {
            closed = false;
        }

        if (Input.GetKeyDown(playKey))
        {

            songManager.CheckNote(closed);
            soundManager.PlayCuica(closed, 0);

            animate.PlayCuica(closed);

        }

        if (Input.GetKeyDown(holdKey) || Input.GetKeyUp(holdKey))
        {
            animate.ShiftCuica(closed);
        }
    }
}
