﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    private string playerTag = "Player";
    private void OnTriggerEnter2D(Collider2D otherCollider2D)
    {   
        if (otherCollider2D.tag == playerTag)
        {
            Player player = otherCollider2D.gameObject.GetComponent<Player>();

            player.ExitLevel();           

        }
    }

}