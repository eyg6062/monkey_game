using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> lowCuicaPfs;
    [SerializeField] private List<GameObject> highCuicaPfs;

    public void PlayCuica(bool closed)
    {
        List<GameObject> soundList;
        if ( closed )
        {
            soundList = highCuicaPfs;
        } 
        else
        {
            soundList = lowCuicaPfs;
        }

        int idx = Random.Range(0, soundList.Count);
        Instantiate(soundList[idx]);
    }

}
