using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetection : MonoBehaviour
{
    [SerializeField]
    private AIBrain brain;
    [SerializeField]
    private List<GameObject> collisons;
    [SerializeField]
    private string[] targetTags;
    private float detectionTimer;
    [SerializeField]
    private float maxSeenTime;
    private AIMovement movment;
    [SerializeField]
    private int maxChaseTime;
    private int chaseTime;
    // Start is called before the first frame update
    void Start()
    {
        //this script grabs the brain from the parrent 
        if (brain == null)
        {
            brain = transform.parent.GetComponent<AIBrain>();
            movment = transform.parent.GetComponent<AIMovement>();
        }
    }

    //check if the things in the detection zone is visable
    void FixedUpdate()
    {
        if (collisons.Count > 0)
        {
            for (int i = 0; i < collisons.Count; i++)
            {
                Debug.Log("beeing called");
                //send out a ray cast to the player and see if it collides while player is in the detection zone
                Vector3 targetDirection = collisons[i].transform.position - transform.position;
                RaycastHit2D lineOfSight = Physics2D.Raycast(transform.position, targetDirection);
                if (lineOfSight.collider != null)
                {
                    Debug.DrawLine(transform.position, lineOfSight.collider.transform.position);
                    if (lineOfSight.collider.gameObject == collisons[i].gameObject)
                    {
                        detectionTimer += Time.deltaTime;
                        if(detectionTimer > maxSeenTime)
                        {
                            detected(lineOfSight.collider.gameObject);
                        }
                    }
                }
            }
        }
    }
    void detected(GameObject detectedOBJ)
    {
        movment.OverideTarget = detectedOBJ;
        StartCoroutine(chase());
    }
    bool checkIfInZone()
    {
        for (int i = 0; i < collisons.Count; i++)
        {
            if(collisons[i].gameObject.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }
    //adds gameobjects to the inneer dettection list
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < targetTags.Length; i++)
        {
            if(collision.gameObject.CompareTag(targetTags[i]))
            {
                collisons.Add(collision.gameObject);
            }
        }
    }

    //removes gameobeject from the inner detection list
    private void OnTriggerExit2D(Collider2D collision)
    {

        for (int i = 0; i < targetTags.Length; i++)
        {
            if (collision.gameObject.CompareTag(targetTags[i]))
            {
                collisons.Remove(collision.gameObject);
            }
        }
    }
    IEnumerator chase()
    {
        while(chaseTime < maxChaseTime)
        {
            yield return new WaitForSeconds(1);
            chaseTime += 1;
        }
        if(checkIfInZone() == true)
        {
            for (int i = 0; i < collisons.Count; i++)
            {
                if (collisons[i].gameObject.tag == "Player")
                {
                    //collisons[i].gameObject.
                }
            }
        } else
        {
            movment.OverideTarget = null;
        }
    }
}
