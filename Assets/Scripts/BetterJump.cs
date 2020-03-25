using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    // Config
    [SerializeField]
    private float fallMultiplier = 3.5f;

    [SerializeField]
    private float lowJumpMultiplier = 3f;

    private string jumpButtonInputName = "Jump";

    // Cached Component Refences
    private Rigidbody2D myRigidbody2D = null;

    private void Start()
    {
        CacheComponentReferences();

        fallMultiplier -= 1; // Unity already accounts of 1 multiple of gravity, so we need to multiply by 1 less than we expect when setting "fallMultiplier"
        lowJumpMultiplier -= 1; // Unity already accounts of 1 multiple of gravity, so we need to multiply by 1 less than we expect when setting "lowJumpMultiplier"
    }

    private void Update()
    {
        if (myRigidbody2D.velocity.y < 0)
        {
            myRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }

        else if (myRigidbody2D.velocity.y > 0 && !Input.GetButton(jumpButtonInputName))
        {
            myRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }
    }

    private void CacheComponentReferences()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }
}
