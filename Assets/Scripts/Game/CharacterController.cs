﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = .1f;
    //private Vector2 targetPos;
    public bool grounded;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position=Vector2.MoveTowards(transform.position)
        //transform.position+=new Vector3(speed,0,0);

        //move character
        if ((GetComponent<Rigidbody2D>().velocity.x<speed))
        { 
            GetComponent<Rigidbody2D>().AddForce(Vector2.right*speed, ForceMode2D.Impulse);
        }
        
        //move main camera
        Camera.main.transform.position = new Vector3(transform.position.x, 0,-20);

        /*UpArrow yerine ekrana dokunmak
         * if (Input.touchCount !=0)
        {
            transform.position += new Vector3(0, 2f, 0);
        }*/

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
        }

        /*animator.SetBool("Grounded", grounded);
        animator.SetFloat("Speed", speed);*/
    }

    private void FixedUpdate()
    {
        GetComponent<Collider2D>()
        grounded = GetComponent<CircleCollider2D>().OverlapPoint(transform.position);
    }
    void Jump()
    {
        if (grounded) { 
        transform.position+= new Vector3(0, 1f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }



}
