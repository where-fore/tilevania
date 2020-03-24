using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 5.0f;

    private Rigidbody2D myRigidBody = null;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        if (Input.GetAxis("Horizontal") > 1)
        {
            Vector2 moveSpeed = new Vector2(runSpeed, 0);
            myRigidBody.velocity = moveSpeed;
        }

        if (Input.GetAxis("Horizontal") < 1)
        {
            Vector2 moveSpeed = new Vector2(runSpeed, 0);
            myRigidBody.velocity = moveSpeed;
        }
    }
}
