using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    void Awake()
    {
        int numberOfMe = FindObjectsOfType<MainUI>().Length;

        if (numberOfMe > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
