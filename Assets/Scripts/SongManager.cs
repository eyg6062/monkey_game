using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    private Controller controller;
    private SoundManager soundManager;

    [SerializeField] private GameObject songPf;
    private AudioSource song;
    [SerializeField] private string midiFilename;
    [SerializeField] private float bpm;

    [SerializeField] private int perfectRange;
    [SerializeField] private int goodRange;

    [SerializeField] private long offset; 
    [SerializeField] private GameObject timerPf;
    private Timer timer;

    private float beatLength;
    private int beatListIdx = 0;
    private List<float> beatList;

    static private float StandardBpm = 60;

    void Awake()
    {
        // get controller 
        controller = gameObject.GetComponent<Controller>();

        // get SoundManager
        soundManager = gameObject.GetComponent<SoundManager>();

        // set up song
        GameObject songObj = Instantiate(songPf);
        song = songObj.GetComponent<AudioSource>();

        // set up timer
        GameObject timerObj = Instantiate(timerPf);
        timer = timerObj.GetComponent<Timer>();
        timer.SetUpTimer(song, offset);

        // set up beat length
        beatLength = (1f / ((float)bpm / StandardBpm) * 1000f);

        // make beat list
        beatList = new List<float>();
        for (int i = 0; i < 128; i++)
        {
            beatList.Add(beatLength * i);
        }
        beatList.Add(float.MaxValue);

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
        
    }

    // called by game manager
    public void StartSong()
    {
        // start song and offset timer
        song.PlayDelayed(1.5f);
        Debug.Log(timer.GetTimer());

    }

    public void Update()
    {
        Debug.Log(timer.GetTimer());

        if (timer.IsActivated())
        {
            if (timer.GetTimer() >= beatList[beatListIdx])
            {
                soundManager.PlayCuica(false);
                
                beatListIdx++;
            }
        }
    }

}
