using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.2f;
    private Rigidbody2D myRigidbody2D;

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        ScrollUp();
    }

    private void Update()
    {
        //ScrollUp();
    }

    private void ScrollUp()
    {
        myRigidbody2D.velocity = new Vector2(0f, scrollSpeed);
    }
}
