using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    private string gameSessionTagString = "GameSession";
    private GameSession theGameSession = null;
    private Text myText = null;

    private void Start()
    {
        CacheComponentReferences();
    }

    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (theGameSession == null) {FindTheGameSession();}

        myText.text = "x " + theGameSession.GetPlayerLives().ToString();
    }

    private void CacheComponentReferences()
    {
        myText = GetComponentInChildren<Text>();
    }
    
    private void FindTheGameSession()
    {
        GameObject gameSessionObject = GameObject.FindGameObjectWithTag(gameSessionTagString);

        theGameSession =  gameSessionObject.GetComponent<GameSession>();
    }
}
