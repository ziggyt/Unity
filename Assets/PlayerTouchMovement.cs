using System;
using UnityEngine;
using System.Collections;
using UnityEngine.iOS;

// Input.GetTouch example.
//
// Attach to an origin based cube.
// A screen touch moves the cube on an iPhone or iPad.
// A second screen touch reduces the cube size.

public class PlayerTouchMovement : MonoBehaviour
{
    public float downwardForce = 20f;
    public float forwardForce = 2000f;
    public float sidewaysForce = 100f;
    
    private float width;
    private float height;

    public Rigidbody rb;

    void Awake()
    {
        width = (float) Screen.width / 2.0f;
        height = (float) Screen.height / 2.0f;
        
    }


    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);

        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 pos = touch.position;

                if (pos.x < width / 2)
                {
                    rb.AddForce(-sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
                }
                else
                {
                    rb.AddForce(sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
                }
            }
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().endGame();
        }
    }
}