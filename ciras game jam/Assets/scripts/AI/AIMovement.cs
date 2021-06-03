using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    private int currentPoint = 0;
    private AIBrain brain;
    [SerializeField]
    private float closeDistence;
    [SerializeField]
    public GameObject OverideTarget;
    [SerializeField]
    private GameObject sightPos;
    [SerializeField]
    private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        brain = gameObject.GetComponent<AIBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Length > 0)
        {
            if (OverideTarget == null)
            {
                if (currentPoint < points.Length)
                {
                    if (Vector3.Distance(transform.position, points[currentPoint].position) > closeDistence)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, brain.speed * Time.deltaTime);
                        // using mousePosition and player's transform (on orthographic camera view)
                        diretion(points[currentPoint]);
                    }
                    else
                    {
                        currentPoint += 1;
                        
                    }
                }
                else
                {
                    currentPoint = 0;
                }
            }
            else
            {
                //this is for if they need to move towards something else like the player
                transform.position = Vector3.MoveTowards(transform.position, OverideTarget.transform.position, brain.speed * Time.deltaTime);
                diretion(OverideTarget.transform);
            }
        }
    }
    void diretion(Transform target)
    {
        var delta = target.position - transform.position;
        if (delta.x >= 0 && !facingRight)
        { // mouse is on right side of player
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // or activate look right some other way
            facingRight = true;
        }
        else if (delta.x < 0 && facingRight)
        { // mouse is on left side
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); // activate looking left
            facingRight = false;
        }
    }
}
