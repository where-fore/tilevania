using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
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
        if (theGameSession == null) {FindTheGameSession();}

        UpdateText();
    }

    private void UpdateText()
    {
        if (theGameSession == null) {FindTheGameSession();}
        
        myText.text = "x " + theGameSession.GetScore().ToString();
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
