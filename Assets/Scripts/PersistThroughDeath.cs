using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://answers.unity.com/questions/1174255/since-onlevelwasloaded-is-deprecated-in-540b15-wha.html
// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html

public class PersistThroughDeath : MonoBehaviour
{
    private bool hasSetMyHome = false;
    private int myHomeIndex;

    public bool setToBeDestroyed = false;

// Magic Methods
    private void OnEnable()// as soon as this script is enabled...
    {
        SceneManager.sceneLoaded += OnLevelLoad; // tell our 'OnLevelLoad' function to start listening for a scene change
    }

    private void OnDisable() // as soon as this script is disabled...
    {
        SceneManager.sceneLoaded -= OnLevelLoad; // tell our 'OnLevelLoad' function to stop listening for a scene change
    }


    private void Start()
    {
        CheckSingleton();
    }

// Methods
    private void OnLevelLoad(Scene scenePlaceholder, LoadSceneMode modePlaceholder) // Placeholders are necessary for the 'delegate' functionality
    {
        CheckIfHome();
    }

    private void CheckIfHome()
    {
        if (!hasSetMyHome)
        {
            SetMyHome();
        }

        if (!IsHome())
        {
            // Debug.Log("destroying due to not home");
            SelfDestruct();
        }

    }

    private void CheckSingleton()
    {
        List<PersistThroughDeath> aliveCopiesOfMe = new List<PersistThroughDeath>();
        
        PersistThroughDeath[] copiesOfMe = FindObjectsOfType<PersistThroughDeath>();
        foreach (PersistThroughDeath copyOfMe in copiesOfMe)
        {
            if (!copyOfMe.setToBeDestroyed)
            {
                aliveCopiesOfMe.Add(copyOfMe);
            }
        }

        if (aliveCopiesOfMe.Count > 1)
        {
            //Debug.Log("destroying due to singleton");
            SelfDestruct();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    private void SetMyHome()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        myHomeIndex = currentSceneIndex;

        hasSetMyHome = true;
    }

    private bool IsHome()
    {
        return myHomeIndex == SceneManager.GetActiveScene().buildIndex;
    }

    private void SelfDestruct()
    {
        setToBeDestroyed = true;
        Destroy(gameObject);
    }
}
