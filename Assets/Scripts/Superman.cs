using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    Vector3 startPos;
    float movementSpeed;
    float jumpForce;
    bool onGround;
    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0.0f, -20.0f, 0.0f);

        startPos = transform.position;
        movementSpeed = 6.0f;
        jumpForce = 10.0f;
        onGround = false;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.x = 0.0f;
        if (Input.GetKey(KeyCode.D))
        {
            eulerAngles.y = 90.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            eulerAngles.y = -90.0f;
        }
        eulerAngles.z = 0.0f;
        transform.eulerAngles = eulerAngles;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
            anim.Play(onGround ? "Running" : "Falling");
        }
        else
        {
            anim.Play(onGround ? "Idle" : "Falling");
        }

        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }
}
