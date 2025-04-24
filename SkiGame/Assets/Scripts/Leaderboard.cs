using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes;
    [SerializeField] private TextMeshProUGUI leaderboardText;
    private void Awake()
    {
        LoadTimes();
        //leaderboardText.gameObject.SetActive(false);
    }

    public void AddRaceTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveTimes();
        UpdateLeaderboardUI();

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
    private void UpdateLeaderboardUI()
    {
        leaderboardText.text = "Best Times:\n";
        for (int i = 0; i < bestTimes.Count && i < 5; i++)
        {
            if (bestTimes[i] < 99999)
                leaderboardText.text += $"{i + 1}. {bestTimes[i]:F2} s\n";
        }
    }

    public void ShowLeaderboard()
    {
        UpdateLeaderboardUI();
        leaderboardText.gameObject.SetActive(true);
    }

}
