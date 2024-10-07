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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {


        Vector3 move = transform.position += transform.forward * forwardSpeed * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCounting < 1)
        {
            jumpCounting++;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;


        }


        if (Input.GetKeyDown(KeyCode.DownArrow) && jumpCounting > 0)
        {
            jumpCounting--;
            rb.AddForce(Vector3.down * downForce, ForceMode.Impulse);
        }




        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;

            ChangeLine();

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;

            ChangeLine();


        }

       
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

