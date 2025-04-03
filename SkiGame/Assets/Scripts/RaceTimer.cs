using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private float penaltyTime = 1;
    [SerializeField] private Leaderboard leaderboard;
    bool timerRunning = false;
    private float raceTime = 0;


    private void Update()
    {
        if (timerRunning)
            raceTime += Time.deltaTime;
    }


    private void OnEnable()
    {
        GameManager.RaceStart += StartRaceTimer;
        GameManager.RaceFinish += StopRaceTimer;
        GameManager.RacePenalty += Penalty;

    }

    private void OnDisable()
    {
        GameManager.RaceStart -= StartRaceTimer;
        GameManager.RaceFinish -= StopRaceTimer;
        GameManager.RacePenalty -= Penalty;
    }

    private void StartRaceTimer()
    {
        raceTime = 0;
        timerRunning = true;
        Debug.Log("race started");
    }

    private void StopRaceTimer()
    {
        timerRunning = false;
        GameData.Instance.racesCompleted++;
        leaderboard.AddRaceTime(raceTime);
        Debug.Log(("Race finished! Race complited: " + GameData.Instance.racesCompleted));
        Debug.Log(("Race finished! Race time: " + raceTime));
    }

    private void Penalty()
    {
        raceTime += penaltyTime;
        Debug.Log("penalty recieved!");
    }


}
