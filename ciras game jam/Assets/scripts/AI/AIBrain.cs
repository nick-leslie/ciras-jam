using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIBrain : MonoBehaviour
{
    //refrence to the player
    private GameObject player;
    //this alows you to get player through script
    public GameObject Player 
    {
        get
        {
            return player;
        }
    }
    [Header("flags")]
    [Header("pathfiding type")]
    private bool patrol;
    private bool flying;
    [Header("combat type")]
    private bool ranged;
    private bool collison;
    private bool melee;
    public bool hold;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //returns a direction of movment
    private Vector3 PathFind()
    {
        return Vector3.zero;
    }
}
