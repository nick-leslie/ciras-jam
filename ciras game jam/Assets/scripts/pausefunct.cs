using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausefunct : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ispaused;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pause()
    {
        if (ispaused == true)
        {
            Time.timeScale = 1;
            ispaused = false;
        }
        else 
        {
            ispaused = true;
            Time.timeScale = 0;
        }
    }
}
