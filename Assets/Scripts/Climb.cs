using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    // Config
    [SerializeField]
    private float climbSpeed = 5f;
    private string tagForClimbableObject = "Ladder";

    private string isClimbingAnimatorBoolString = "IsClimbing";

    // Cached Component References
    private Collider2D myCollider2D = null;

    private Animator myAnimator = null;

    private Rigidbody2D myRigidbody2D = null;

    void Start()
    {
        CacheComponentReferences();
    }

    private void OnTriggerStay2D(Collider2D colliderOfTrigger)
    {
        if (colliderOfTrigger.gameObject.tag == tagForClimbableObject)
        {
            ClimbUp();
            PlayClimbAnimation();
        }
    }

    private void OnTriggerExit2D(Collider2D colliderOfTrigger)
    {
        if (colliderOfTrigger.gameObject.tag == tagForClimbableObject)
        {
            StopClimbingAnimation();
        }
    }

    private void ClimbUp()
    {
        Vector2 moveSpeed = new Vector2(0, climbSpeed);
        myRigidbody2D.velocity = moveSpeed;
    }

    private void PlayClimbAnimation()
    {
        myAnimator.SetBool(isClimbingAnimatorBoolString, true);
    }

    private void StopClimbingAnimation()
    {
        myAnimator.SetBool(isClimbingAnimatorBoolString, false);
    }
    
    private void CacheComponentReferences()
    {
        myCollider2D = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }
}
