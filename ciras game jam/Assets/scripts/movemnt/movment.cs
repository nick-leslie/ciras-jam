using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class movment : MonoBehaviour
{
    private Rigidbody2D PlayerRigidbody;
    public float moveSpeed = 1f;
    public float jumpForce = 1f;
    public GameObject feet;
    public float JumpTime;
    public float MaxJumpTime = .1f;
    public float maxSpeed;
    public void Awake()
    {
        PlayerRigidbody = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (PlayerRigidbody != null)
        {
            ApplyInput();
        }
        else
        {
            Debug.Log("yo shit dose aint it");
        }
        if (feet.GetComponent<grownded>().Grownded == true)
        {
            JumpTime = 0;

        }
        Debug.Log(PlayerRigidbody.velocity.magnitude);
       if (PlayerRigidbody.velocity.magnitude > maxSpeed)
        {
            PlayerRigidbody.velocity = PlayerRigidbody.velocity.normalized * maxSpeed;
        }
    }
    public void ApplyInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xForce = xInput * moveSpeed * Time.deltaTime;
        float yForce = 0;
        if (yInput > 0)
        {
            if (JumpTime < MaxJumpTime)
            {
                JumpTime += Time.deltaTime;
                yForce = yInput * jumpForce * Time.deltaTime;
            }
        }

        Vector2 force = new Vector2(xForce, yForce);


        PlayerRigidbody.AddForce(force);
    }
}

