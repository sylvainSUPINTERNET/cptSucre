using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    Animation animations;
    CapsuleCollider capsuleCollider;

    float walkSpeed = 0.6f;
    float rotateSpeed = 200f;

    bool isRunning = false;
    

    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
          animations.Play("attack");
            Debug.Log("Space key was pressed.");
        }

        if ( Input.GetKey(KeyCode.E) )
        {
            isRunning = true;
            walkSpeed = 6f;
        } else {
            isRunning = false;
            walkSpeed = 0.6f;
        }

        if (Input.GetKey(KeyCode.Z))
        {
          transform.Translate(0f,0f, walkSpeed * Time.deltaTime);

          if ( isRunning == true ) {
            animations.Play("run");
          } else {
            animations.Play("walk");
          }

        }

        if (Input.GetKey(KeyCode.D))
        {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
          if ( isRunning == true ) {
            animations.Play("run");
          } else {
            animations.Play("walk");
          }
        }

        if (Input.GetKey(KeyCode.Q))
        {
          transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
          if ( isRunning == true ) {
            animations.Play("run");
          } else {
            animations.Play("walk");
          }
        }

        if (Input.GetKey(KeyCode.S))
        {
          transform.Translate(0f,0f, -(walkSpeed/2) * Time.deltaTime);
          if ( isRunning == true ) {
            animations.Play("run");
          } else {
            animations.Play("walk");
          }
        }

    }
}
