using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{

    public DemoPlayer musicPlayer;
    public Color themeLoadedColor;

    [Range(1, 14)]
    public int newIntensityLevel;
    private int currentIntensityLevel;
    public bool stop;
    public bool start;
    private bool startLastClicked;


    private uint nr_loop_tracks = 0;
    private uint nr_stinger_tracks = 0;
    private uint greatestTrigger = 0;



    // MusicSwitcher register itself to listen for events of the type ExampleTrigger.ZoneTriggered
    void OnEnable()
    {
        ExampleTrigger.OnZoneTriggered += Switch;
        ExampleTrigger.OnThemeLoaded += ThemeLoaded;
    }

    void OnDisable()
    {
        ExampleTrigger.OnZoneTriggered -= Switch;
        ExampleTrigger.OnThemeLoaded -= ThemeLoaded;
    }

    void Start()
    {
        currentIntensityLevel = newIntensityLevel;
        
    }



    void Update()
    {

        if(!start && !stop && startLastClicked)
        {
            start = true;
        }
        else if(!start && !stop && !startLastClicked)
        {
            stop = true;
        }

        else if (start && !startLastClicked)
        {
            musicPlayer.StartTheme();
            stop = false;
            startLastClicked = true;
        }
        else if (stop)
        {
            musicPlayer.StopTheme();
            start = false;
            startLastClicked = false;
        }

        if (newIntensityLevel != currentIntensityLevel)
        {
            musicPlayer.SetLevel(newIntensityLevel, newIntensityLevel, 80, 0, 0, 0);//TODO make variables for last arguments..
            currentIntensityLevel = newIntensityLevel;

        }



    }
    public void setNewIntensityLevel(int intensityLevel)
    {
        newIntensityLevel = intensityLevel;
    }



    // Called when a theme has finished loading.
    public void ThemeLoaded(ref Elias.Theme theme)
    {
        //gameObject.GetComponent<Renderer>().material.color = themeLoadedColor;
        nr_loop_tracks = theme.AudioLoopTrackCount;
        nr_stinger_tracks = theme.AudioStingerTrackCount;
        greatestTrigger = (uint)theme.GreatestTrigger;
        Debug.Log(string.Format("ELIASMusicSwitcher - A theme with {0} loop tracks was loaded.", nr_loop_tracks));
    }

    // This method should get called if a LevelTrigger is triggered.
    public void Switch(uint zone_id, ExampleTrigger.TrackType trackType)
    {

        // Need mapping between zone_id for a stinger trigger
        if (trackType == ExampleTrigger.TrackType.stinger)
        {
            int track_id = (int)zone_id;

            //  Keep id within bounds.
            if ((uint)track_id < nr_loop_tracks + 1)
            {
                track_id = (int)nr_loop_tracks + 1;
            }
            if (track_id > (nr_stinger_tracks + nr_loop_tracks))
            {
                track_id = (int)nr_stinger_tracks + (int)nr_loop_tracks;
            }
            musicPlayer.PlayStinger(track_id);
            return;
        }

        // Set loop track trigger level.
        if (zone_id > greatestTrigger)
        {
            zone_id = greatestTrigger;
        }
        musicPlayer.SetLevel((int)zone_id, (int)zone_id, 100, 0, 1, 0);
    }

}
