using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int startMenuSceneIndex = 0;
    //[SerializeField] private int optionsMenuSceneIndex;
    [SerializeField] private int congratulationsSceneIndex = 0;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void LoadNextLevel()
    {
        LoadNextLevel(0f);
    }
    public void LoadNextLevel(float delay)
    {
        StartCoroutine(DelayThenLoadNextSceneCoroutine(delay));
    }


    public void LoadMainMenu()
    {
        LoadMainMenu(0f);
    }
    public void LoadMainMenu(float delay)
    {
        StartCoroutine(DelayThenLoadSceneCoroutine(delay, startMenuSceneIndex));
    }

/*
    public void LoadOptionsMenu()
    {
        LoadOptionsMenu(0f);
    }
    public void LoadOptionsMenu(float delay)
    {
        StartCoroutine(DelayThenLoadSceneCoroutine(delay, optionsMenuSceneIndex));
    }
*/

    public void LoadCongratulationsScene()
    {
        LoadCongratulationsScene(0f);
    }
    public void LoadCongratulationsScene(float delay)
    {
        StartCoroutine(DelayThenLoadSceneCoroutine(delay, congratulationsSceneIndex));
    }


    public void QuitGame()
    {
        QuitGame(0f);
    }
    public void QuitGame(float delay)
    {
        StartCoroutine(DelayThenQuitGame(delay));
    }


    public void RestartLevel()
    {
        RestartLevel(0f);
    }
    public void RestartLevel(float delay)
    {
        StartCoroutine(DelayThenLoadSceneCoroutine(delay, SceneManager.GetActiveScene().buildIndex));
    }


    private IEnumerator DelayThenLoadNextSceneCoroutine(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator DelayThenLoadSceneCoroutine(float delay, int sceneToLoadBuildIndex)
    {
        yield return new WaitForSecondsRealtime(delay);

        SceneManager.LoadScene(sceneToLoadBuildIndex);
    }

    private IEnumerator DelayThenQuitGame(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        Application.Quit();
    }

}
