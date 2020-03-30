using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    private float levelRestartOnDeathDelay = 2f;

    private int playerLives = 3;
    private int score = 0;

    private string sceneLoaderTagString = "SceneLoader";
    private SceneLoader theSceneLoader = null;

    void Awake()
    {
        int numberofGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberofGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        CacheComponentReferences();
    }

    public void ProcessPlayerDeath()
    {

        if (playerLives > 1)
        {
            TakeLife();
            theSceneLoader.RestartLevel(levelRestartOnDeathDelay);
        }
        else
        {
            ResetGameSession(levelRestartOnDeathDelay);
        }
    }

    public void AddToScore(int amount)
    {
        score += amount;
    }

    public int GetPlayerLives()
    {
        return playerLives;
    }

    public int GetScore()
    {
        return score;
    }

    private void TakeLife()
    {
        playerLives--;
    }
 
    private void ResetGameSession(float delay)
    {
        StartCoroutine(actuallyResetGameSession(delay));
    }

    private IEnumerator actuallyResetGameSession(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        theSceneLoader.LoadMainMenu();
        Destroy(gameObject);
    }
    
    private void CacheComponentReferences()
    {
        theSceneLoader = GameObject.FindGameObjectWithTag(sceneLoaderTagString).GetComponent<SceneLoader>();
    }
}
