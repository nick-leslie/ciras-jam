using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammraTests : MonoBehaviour
{
    //yes I know there is better ways to do this but I am to lazy to learn the unity testing frame work
    public bool RunTests;
    public float holdDuration;
    public GameObject cam;
    public Transform[] targetList;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(RunTests)
        {
            cammraControler controler = cam.GetComponent<cammraControler>();
            //checking if cammra controler exists
            if (controler != null)
            {
                if (targetList.Length > 1)
                {
                    StartCoroutine(controler.StartCinimatic(0.5f, targetList));
                }
                else
                {
                    controler.StartCinimatic(0.5f, targetList[0]);
                }
            }
            RunTests = false;
        }
    }
}
