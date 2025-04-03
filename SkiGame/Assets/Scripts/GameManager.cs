using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void RaceEvent();
    public static event RaceEvent RaceStart;
    public static event RaceEvent RacePenalty;
    public static event RaceEvent RaceFinish;
    public static event RaceEvent GameQuit;

    public static void CallGameQuit()
    {
        if (GameQuit != null)
            GameQuit();
    }

    public static void CallRaceStart()
    {
        if (RaceStart != null)
            RaceStart();
    }

    public static void CallRaceFinish()
    {
        if (RaceFinish != null)
            RaceFinish();
    }

    public static void CallRacePenalty()
    {
        if (RacePenalty != null)
            RacePenalty();
    }
}
