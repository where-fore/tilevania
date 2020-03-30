using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSupervisor : MonoBehaviour
{
    void Awake()
    {
        int numberOfGameSupervisors = FindObjectsOfType<GameSupervisor>().Length;

        if (numberOfGameSupervisors > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
