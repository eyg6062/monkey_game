using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private SongManager songManager;

    private void Awake()
    {
        songManager = gameObject.GetComponent<SongManager>();
    }

    void Start()
    {
        songManager.StartSong();
    }

}
