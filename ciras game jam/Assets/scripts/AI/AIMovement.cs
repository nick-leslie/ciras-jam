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
    // Start is called before the first frame update
    void Start()
    {
        brain = gameObject.GetComponent<AIBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OverideTarget != null)
        {
            if (currentPoint < points.Length)
            {
                if (Vector3.Distance(transform.position, points[currentPoint].position) > closeDistence)
                {
                    transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, brain.speed * Time.deltaTime);
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
        } else
        {
            //this is for if they need to move towards something else like the player
            transform.position = Vector3.MoveTowards(transform.position, OverideTarget.transform.position, brain.speed * Time.deltaTime);
        }
    }
}
