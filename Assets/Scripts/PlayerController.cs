using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 direction;
    [SerializeField] public float forwardSpeed;

    private int desiredLane = 1;
    [SerializeField] private float laneDistance = 1.5f; 

    [SerializeField] private float jumpForce = 30;
    [SerializeField] private float downForce = 60;

    private Rigidbody rb;

    private int jumpCounting;

    private bool isJumping = false;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Vector3 move = transform.position += transform.forward * forwardSpeed * Time.deltaTime;
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            Vector2 inputVector = endTouchPosition - startTouchPosition;
            if(Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
            {
                if(inputVector.x > 0)
                {
                    RightSwipe();
                }
                else
                {
                    LeftSwipe();
                }
            }
            else
            {
                if (inputVector.y > 0)
                {
                    UpSwipe();
                }
                else
                {
                    DownSwipe();
                }
            }
        }

    }

    private void UpSwipe()
    {
        jumpCounting++;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }
    private void DownSwipe()
    {
        jumpCounting--;
        rb.AddForce(Vector3.down * downForce, ForceMode.Impulse);
    }
    private void LeftSwipe()
    {
        desiredLane--;
        if (desiredLane == -1)
            desiredLane = 0;

        ChangeLine();
    }
    private void RightSwipe()
    {
        desiredLane++;
        if (desiredLane == 3)
            desiredLane = 2;

        ChangeLine();
    }

    private void ChangeLine()
    {
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        
        transform.position = targetPosition;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCounting = 0;
            isJumping= false;
        }
    }

    public bool IsJumping() 
    {
        return isJumping; 
    }
}
