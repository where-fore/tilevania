using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private int playerLives = 2;
    private float levelRestartOnDeathDelay = 2f;

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
