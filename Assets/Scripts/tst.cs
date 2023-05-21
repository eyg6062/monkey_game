using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tst : MonoBehaviour
{

    private float timer = 0;
    private float testTimer = 0;
    private AudioSource audioSource;
    [SerializeField] private GameObject lowCuica1Pf;

    // static private float StandardBPM = 60;

    // Start is called before the first frame update
    void Start()
    {
        MidiFile file = MidiFile.Read("Assets/Audio/cuica_midi.mid");
        ICollection<Note> notes = file.GetNotes();

        List<long> timings = new List<long>();

        foreach(Note note in notes)
        {
            TimedEvent te = note.GetTimedNoteOnEvent();
            long time = note.Time;

            timings.Add(time);
        }

        //float bpm = 175.96; // for the elevator music


        // grab audio thing
        GameObject soundObject = GameObject.Find("low cuica test");
        audioSource =  soundObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        timer += Time.deltaTime * 1000;

        testTimer += Time.deltaTime * 1000;
        if (testTimer >= 200)
        {
            Instantiate(lowCuica1Pf);
            testTimer = 0;
        }

    }
}
