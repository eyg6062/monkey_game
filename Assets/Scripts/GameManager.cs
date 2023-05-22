using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private SongManager songManager;

    [SerializeField] GameObject buttonScriptObjectPf;

    private void Awake()
    {
        songManager = gameObject.GetComponent<SongManager>();
    }

    void Start()
    {
        Instantiate(buttonScriptObjectPf);
        songManager.StartSong();
    }

}
