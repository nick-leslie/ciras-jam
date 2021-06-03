using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grownded : MonoBehaviour
{
    public bool Grownded;

    public LayerMask ground;


    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        if (ground==(ground | (1 << col.gameObject.layer)))
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            Grownded = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (ground ==(ground | (1 << col.gameObject.layer)))
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            Grownded = false;
        }
    }
 
}
