﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    
    public float speed;
    public CharacterController controller;
    private Vector3 position;

    public Animation run;
   // public AnimationClip idle;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        run = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            locatePosition();
        }

        moveToPosition();
    }

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        if(Physics.Raycast(ray, out hit, 1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Debug.Log(position);
        }
    }

    void moveToPosition()
    {
        // Game Object in moving
        if (Vector3.Distance(transform.position, position) > 2)
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);
           
            newRotation.x = 0f;
            newRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward);

         //   GetComponent<Animation>().CrossFade("run");
          //  run.Play("Run");

            run.CrossFade("Run");
            run.Play();
        }
        /// Gabe object is note moving
        else
        {
          //  GetComponent<Animation>().CrossFade("idle");
        }
    }
}
