using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{

    [SerializeField] private GameObject SongPf;
    [SerializeField] private string midiFilename;
    [SerializeField] private float bpm;

    [SerializeField] private int perfectRange;
    [SerializeField] private int goodRange;

    static private float StandardBpm = 60;

    void Awake()
    {
        // load in midi file, get note list
        MidiFile file = MidiFile.Read("Assets/Audio/" + midiFilename + ".mid");
        ICollection<Note> midiNotes = file.GetNotes();

        List<MapNote> mapNotes = new List<MapNote>();

        foreach (Note note in midiNotes)
        {
            // get if closed or open
            bool closed = false;
            int pitch = note.NoteNumber;
            if (pitch >= 61)
            {
                closed = true;
            }

            // get note timing, convert to 60bpm, then to specified bpm
            long rawTime = note.GetTimedNoteOnEvent().Time;
            long time60 = rawTime * 25 / 24;
            long time = (long)(  1 / (bpm / StandardBpm) * (float)time60  );

            // add mapNote to list
            MapNote mapNote = new MapNote(closed, time);
            mapNotes.Add(mapNote);

        }

        // debug
        foreach (MapNote mapNote in mapNotes)
        {
            Debug.Log(mapNote.ToString());
        }

        // load in song
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
