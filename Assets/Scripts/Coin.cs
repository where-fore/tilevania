using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip pickupAudioClip = null;
    private string playerTag = "Player";
    private string mainCameraTag = "MainCamera";
    private void OnTriggerEnter2D(Collider2D otherCollider2D)
    {   
        if (otherCollider2D.tag == playerTag)
        {
            Player player = otherCollider2D.gameObject.GetComponent<Player>();

            PickUp();         

        }
    }

    private void PickUp()
    {
        AudioSource.PlayClipAtPoint(pickupAudioClip, FindTheGameCamera().transform.position);
        Destroy(gameObject);
    }
    
    private GameObject FindTheGameCamera()
    {
        return GameObject.FindGameObjectWithTag(mainCameraTag);
    }
}
