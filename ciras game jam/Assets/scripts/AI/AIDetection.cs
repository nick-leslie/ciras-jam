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
    // Start is called before the first frame update
    void Start()
    {
        //this script grabs the brain from the parrent 
        if (brain == null)
        {
            brain = transform.parent.GetComponent<AIBrain>();
        }
    }

    // Update is called once per frame
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
                Debug.DrawLine(transform.position, lineOfSight.collider.transform.position);
                if (lineOfSight.collider != null)
                {
                    if(lineOfSight.collider.gameObject == collisons[i].gameObject)
                    {
                        detected();
                    }
                }
            }
        }
    }
    void detected()
    {

    }
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
}
