using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Image overlay;
    [SerializeField] private int nextLevelIndex = 1;

    private void Start()
    {
        overlay.CrossFadeAlpha(0, 1.5f,true);
        gameOverUI.SetActive(false);
    }
    private void OnEnable()
    {
        GameManager.RaceFinish += EnableGameOverUI;
        GameManager.GameQuit += Quit;
    }

    private void OnDisable()
    {
        GameManager.RaceFinish -= EnableGameOverUI;
        GameManager.GameQuit -= Quit;
    }

    private void EnableGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        overlay.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   

    public void GoToNextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator NextLevelCoroutine()
    {
        overlay.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void GameQuit()
    {
        GameManager.CallGameQuit();
    }
    private IEnumerator QuitCoroutine()
    {
        overlay.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        Application.Quit();
     
    }
    private void Quit()
    {
        StartCoroutine(QuitCoroutine());
        Debug.Log("Quit Game");
    }

}
