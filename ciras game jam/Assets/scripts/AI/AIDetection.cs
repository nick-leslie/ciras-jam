using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetection : MonoBehaviour
{
    private AIBrain brain;
    // Start is called before the first frame update
    void Start()
    {
        //this script grabs the brain from the parrent 
       brain = transform.parent.GetComponent<AIBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //send out a ray cast to the player and see if it collides while player is in the detection zone
        Vector3 playerDirection = brain.Player.transform.position - transform.position;
        RaycastHit2D lineOfSight = Physics2D.Raycast(transform.position, playerDirection);
        if(lineOfSight.collider != null)
        {
            Debug.Log(lineOfSight.collider.name);
        }
    }
}
