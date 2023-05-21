using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    private Controller controller;
    private SoundManager soundManager;

    [SerializeField] private GameObject songPf;
    private AudioSource song;
    [SerializeField] private string demoMidiFilename;
    [SerializeField] private string mapMidiFilename;
    [SerializeField] private float bpm;

    private List<MapNote> demoNotes;
    private int demoNotesIdx = 0;
    private MapNote currDemoNote;

    private List<MapNote> mapNotes;
    private int mapNotesIdx = 0;
    private MapNote currMapNote;

    [SerializeField] private float perfectRange;
    [SerializeField] private float goodRange;

    [SerializeField] private long offset; 
    [SerializeField] private GameObject timerPf;
    private Timer timer;

    private float beatLength;
    private int beatListIdx = 0;
    private List<float> beatList;

    private GameObject lilMoke;
    private MonkeyAnimate animate;

    private GameObject bigMokeEffect;
    private EffectAnimate effectAnimate;

    private GameObject lilMokeEffect;
    private EffectAnimate lilMokeEffectAnimate;

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

        // reads midi for demoMap and beatMap
        demoNotes = ReadMapNotes(demoMidiFilename);
        currDemoNote = demoNotes[0];

        mapNotes = ReadMapNotes(mapMidiFilename);
        currMapNote = mapNotes[0];

        /*
        foreach (MapNote mapNote in demoNotes)
        {
            Debug.Log(mapNote.ToString());
        }
        */
        
    }

    private void Start()
    {
        lilMoke = GameObject.FindGameObjectWithTag("Lil Moke");
        animate = lilMoke.GetComponent<MonkeyAnimate>();

        bigMokeEffect = GameObject.FindGameObjectWithTag("Big Moke Effect");
        effectAnimate = bigMokeEffect.GetComponent<EffectAnimate>();

        lilMokeEffect = GameObject.FindGameObjectWithTag("Lil Moke Effect");
        lilMokeEffectAnimate = lilMokeEffect.GetComponent<EffectAnimate>();
    }

    private List<MapNote> ReadMapNotes(string strMidiFilename)
    {
        List<MapNote> mapNotesList = new List<MapNote>();

        // load in midi file, get note list
        MidiFile file = MidiFile.Read("Assets/Audio/" + strMidiFilename + ".mid");
        ICollection<Note> midiNotes = file.GetNotes();

        mapNotesList = new List<MapNote>();

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
            long time = (long)(1 / (bpm / StandardBpm) * (float)time60);

            // add mapNote to list
            MapNote mapNote = new MapNote(closed, time);
            mapNotesList.Add(mapNote);

        }
        mapNotesList.Add(new MapNote(false, long.MaxValue));

        return mapNotesList;
        
    }

    // called by game manager
    public void StartSong()
    {
        // start song and offset timer
        song.PlayDelayed(2.5f);
        //Debug.Log(timer.GetTimer());

    }

    public void CheckNote(bool closed)
    {
        float msOff = currMapNote.GetTiming() - timer.GetTimer();
        float msOffAbs = math.abs(msOff);
        Debug.Log(msOff);

        if (closed == currMapNote.IsClosed())
        {

            if (msOffAbs <= perfectRange)
            {
                effectAnimate.Perfect();
                Debug.Log("perfect");
                NextMapNote();
            }
            else if (msOffAbs <= goodRange)
            {
                effectAnimate.Good();
                Debug.Log("good");
                NextMapNote();
            }
            else
            {
                effectAnimate.Miss();
                Debug.Log("miss");
            }

        } 
        else
        {
            effectAnimate.Miss();
            Debug.Log("miss");
        }

        
    }

    private void NextMapNote()
    {
        mapNotesIdx++;
        currMapNote = mapNotes[mapNotesIdx];
    }

    public void Update()
    {
        //Debug.Log(timer.GetTimer());

        if (timer.IsActivated())
        {

            if (timer.GetTimer() >= currDemoNote.GetTiming()   /*beatList[beatListIdx]*/  )
            {
                soundManager.PlayCuica(currDemoNote.IsClosed(), 1);

                animate.PlayCuica(currDemoNote.IsClosed());

                lilMokeEffectAnimate.LilMokePlay();

                demoNotesIdx++;
                currDemoNote = demoNotes[demoNotesIdx];
                //beatListIdx++;
            }

            if (timer.GetTimer() > currMapNote.GetTiming() + goodRange)
            {
                Debug.Log("miss");
                NextMapNote();
            }

        }


    }

}
