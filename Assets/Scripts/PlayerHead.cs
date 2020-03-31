using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    private string waterLayerString = "Water";
    private Player playerParent;
    private LayerMask waterLayer;
    
    private void Start()
    {
        playerParent = transform.parent.GetComponent<Player>();
        waterLayer = LayerMask.GetMask(waterLayerString);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider2D)
    {
        Debug.Log("head trigger enter");
        if (1 << otherCollider2D.gameObject.layer == waterLayer.value) //https://forum.unity.com/threads/get-the-layernumber-from-a-layermask.114553/
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        playerParent.KillPlayer();
    }
}
