using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private LayerMask[] layersThatKillMe = new LayerMask[0];
    [SerializeField] private Sprite deadSprite;
    [SerializeField] private Vector2 deathAnimationForce = Vector2.zero;
    [SerializeField] private float deathTimeScale = 0.3f;
    
    private string horizontalMovementInputString = "Horizontal";
    private string isAliveAnimationString = "IsAlive";
    private string exitingLevelAnimationString = "ExitingLevel";
    private string sceneLoaderTagString = "SceneLoader";
    private string gameSessionTagString = "GameSession";
    private string timeKeeperTagString = "TimeKeeper";

    private bool alive = true;

    private bool invulnerable = false;

    // Cached Component References
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private SceneLoader theSceneLoader = null;
    private TimeKeeper  theTimeKeeper = null;


    // Messages then methods
    void Start()
    {
        CacheComponentReferences();
    }

    void Update()
    {
        if (alive)
        {
            ListenForMovementInputs();
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        CheckForDeath(collisionData.collider);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider2D)
    {
        CheckForDeath(otherCollider2D);
    }

 // Used in Animation Events
    public void FinishExitingLevel()
    {
        theSceneLoader.LoadNextLevel();
    }
    public void StartExitingLevel()
    {

    }
// End of Animation Events

    private void CheckForDeath(Collider2D otherCollider2D)
    {
        if (!invulnerable)
        {
            foreach (LayerMask deathlyLayer in layersThatKillMe)
            {
                if (1 << otherCollider2D.gameObject.layer == deathlyLayer.value) //https://forum.unity.com/threads/get-the-layernumber-from-a-layermask.114553/
                {
                    if (alive) { Die(); }
                }
            }
        }

    }

    private void Die()
    {
        alive = false;
        myRigidbody2D.velocity = deathAnimationForce;
        myAnimator.SetBool(isAliveAnimationString, false);
        theTimeKeeper.SetTimeScale(deathTimeScale);
        
        FindTheGameSession().GetComponent<GameSession>().ProcessPlayerDeath();
    }

    private void ListenForMovementInputs()
    {
        Run(Input.GetAxis(horizontalMovementInputString));
    }

    private void Run(float runButtonPressedAmount)
    {
        Vector2 moveSpeed = new Vector2(runSpeed * runButtonPressedAmount, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = moveSpeed;
    }

    public void ExitLevel()
    {
        SetInvulnerability(true);
        
        myAnimator.SetTrigger(exitingLevelAnimationString);
    }

    private void SetInvulnerability(bool nowInvulnerableBool)
    {
        invulnerable = nowInvulnerableBool;
    }



    

    private void CacheComponentReferences()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        theSceneLoader = GameObject.FindGameObjectWithTag(sceneLoaderTagString).GetComponent<SceneLoader>();
        theTimeKeeper = GameObject.FindGameObjectWithTag(timeKeeperTagString).GetComponent<TimeKeeper>();
    }

    private GameObject FindTheGameSession()
    {
        return GameObject.FindGameObjectWithTag(gameSessionTagString);
    }
    
}
