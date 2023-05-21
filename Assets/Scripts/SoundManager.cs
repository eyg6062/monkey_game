using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> lowCuicaPfs;
    [SerializeField] private List<GameObject> highCuicaPfs;

    // big moke is 0, lil moke is 1
    public void PlayCuica(bool closed, int monkeyNumber)
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

        Vector3 pos;
        if (monkeyNumber == 0)
        {
            pos = new Vector3(8f, 0f, 0f);
        } 
        else
        {
            pos = new Vector3(-12f, .2f, 24);
        }

        int idx = Random.Range(0, soundList.Count);
        Instantiate(soundList[idx], pos, Quaternion.identity);
    }

}
