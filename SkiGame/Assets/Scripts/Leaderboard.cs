using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes;
    private void Awake()
    {
        LoadTimes();
    }

    public void AddRaceTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveTimes();

    }

    private void SaveTimes()
    {
        for (int i = 0; i < 5; i++) 
        {
            if(i < bestTimes.Count)
                PlayerPrefs.SetFloat("time" + i, bestTimes[i]);
        }
        PlayerPrefs.Save();
    }

    private void LoadTimes()
    {
        bestTimes = new List<float>();
        for (int i = 0; i<5; i++ )
        {
            bestTimes.Add(PlayerPrefs.GetFloat("time" + i, 99999));
        }
    }
   
}
