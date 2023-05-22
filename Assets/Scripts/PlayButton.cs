using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

    }

    private void OnMouseEnter()
    {
        
    }

    private void OnMouseDown()
    {
        soundManager.PlayCuica(false, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
