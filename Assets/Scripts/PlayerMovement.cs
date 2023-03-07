using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public Rigidbody rb;
   public GameObject Human;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    public Vector3 temp = new Vector3(0,0,0);
    // if velocity is 0,0,0 and we get input, add force to corrispond to input

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {  
            endTouchPosition = Input.GetTouch(0).position;

            if(Mathf.Abs(endTouchPosition.x - startTouchPosition.x) > Mathf.Abs(endTouchPosition.y - startTouchPosition.y))
            {
                if(endTouchPosition.x < startTouchPosition.x)
                {
                    Up();
                    Human.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.up);
                }
            
                if(endTouchPosition.x > startTouchPosition.x)
                {
                    Down();
                    Human.transform.rotation = Quaternion.LookRotation(Camera.main.transform.up);
                }
            }
           
           if(Mathf.Abs(endTouchPosition.y - startTouchPosition.y) > Mathf.Abs(endTouchPosition.x - startTouchPosition.x))
            {
                if(endTouchPosition.y < startTouchPosition.y)
                {
                    Left();
                    Human.transform.rotation = Quaternion.LookRotation(Camera.main.transform.right);
                }
            
                if(endTouchPosition.x > startTouchPosition.x)
                {
                    Right();
                    Human.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.right);
                }
            }
        }
        
    }

    public void Right()
    {
        if(rb.velocity == temp)
        {
            rb.AddForce(10,0,0,ForceMode.Impulse);
        }
    }
    public void Left()
    {
        if(rb.velocity == temp)
        {
            rb.AddForce(-10,0,0,ForceMode.Impulse);
        }
    }
    public void Up()
    {
        if(rb.velocity == temp)
        {
            rb.AddForce(0,0,10,ForceMode.Impulse);
        }
    }
    public void Down()
    {
        if(rb.velocity == temp)
        {
            rb.AddForce(0,0,-10,ForceMode.Impulse);
        }
    }
}
