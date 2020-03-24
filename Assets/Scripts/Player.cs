using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 5.0f;

    private RigidBody myRigidBody = null;



    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<RigidBody2d>();
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
            myRigidBody.velocity = runSpeed;
        }

        if (Input.GetAxis("Horizontal") < 1)
        {
            myRigidBody.velocity = runSpeed;
        }
    }
}
