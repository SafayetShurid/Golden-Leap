using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform parent;
    public Transform target;

    public float speed;


    public float maxSwipetime;
    public float minSwipeDistance;

    private float swipeStartTime;
    private float swipeEndTime;

    private Vector2 startSwipePosition;
    private Vector2 endSwipePosition;

    private float swipeTime;
    private float swipeLength;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetMouseButtonDown(0))
        {
            Vector3 dir = target.position - transform.position;
            Debug.Log(dir);
            Debug.Log(dir.normalized);
            rb.AddForce(dir * speed);
            GameManager.instance.PlayRailJumpSound() ;
        }*/


        if (transform.localPosition.x<0f)
        {
            Vector3 rot = new Vector3(0f, 0f, 50f);
            transform.localRotation = Quaternion.Euler(rot);
            
        }

        if (transform.localPosition.x > 0f)
        {
            Vector3 rot = new Vector3(0f, -180f, 50f);
            transform.localRotation = Quaternion.Euler(rot);

        }

        SwipeTest();
    }

    public void SwipeTest()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                swipeStartTime = Time.time;
                startSwipePosition = touch.position;
            }
            else if(touch.phase==TouchPhase.Ended)
            {
                swipeEndTime = Time.time;
                endSwipePosition = touch.position;
                swipeTime = swipeEndTime - swipeStartTime;
                swipeLength = (endSwipePosition - startSwipePosition).magnitude;
               
                if (swipeTime<maxSwipetime && swipeLength > maxSwipetime)
                {
                    swipeControl();
                }

            }
        }
    }

    private void swipeControl()
    {
        Vector2 Distance = endSwipePosition - startSwipePosition;
        float xDistance = Mathf.Abs(Distance.x);
        float yDistance = Mathf.Abs(Distance.y);

       if(xDistance>yDistance)
        {
            Vector3 dir = target.position - transform.position;          
            rb.AddForce(dir * speed);
            GameManager.instance.PlayRailJumpSound();
        }
           
        

    }
}
