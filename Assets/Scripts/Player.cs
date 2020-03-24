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
        Vector2 moveSpeed = new Vector2(runSpeed * Input.GetAxis("Horizontal"), myRigidBody.velocity.y);
        myRigidBody.velocity = moveSpeed;
    }
}
