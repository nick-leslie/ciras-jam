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
    public void Awake()
    {
        PlayerRigidbody = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(PlayerRigidbody !=null)
        {
            ApplyInput(); 
        } else
        {
            Debug.Log("yo shit dose not subsist");
        }

    
    }
    public void ApplyInput() 
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xForce = xInput * moveSpeed * Time.deltaTime;
        float yForce = 0;
        if (feet.GetComponent<grownded>().Grownded == true)
        {
             yForce = yInput * jumpForce * Time.deltaTime;
        }
        

        Vector2 force = new Vector2(xForce, yForce);


        PlayerRigidbody.AddForce(force);
    }

}

