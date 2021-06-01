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
    [Header("genaral stuff")]
    public int speed;
    [Header("flags")]
    [Header("pathfiding type")]
    public bool patrol;
    public bool flying;
    [Header("combat type")]
    public bool ranged;
    public bool collison;
    public bool melee;
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
}
