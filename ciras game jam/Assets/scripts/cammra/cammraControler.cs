using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammraControler : MonoBehaviour
{
    [Header("tracking varubles")]
    [SerializeField]
    private Transform defaltTracked; // this is the defalt thing that is tracked
    [SerializeField]
    private Transform currentTracked; // this is the current thing that is tracked
    [Header("peramiters")]
    public float cammraSpeed;
    public float closeDistence;
    [SerializeField]
    private float cammraZ;
    [Header("flags")]
    [SerializeField]
    private bool smooth;


    //this is for lerping to a static position if the smooth flag is set
    [SerializeField]
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(currentTracked.position.x, currentTracked.position.y, cammraZ);
        if (smooth == false)
        {
            //this is the path for if it is just tracking 
            //this is most commonly used during gameplay 
            transform.position = target;
        } else
        {
            //this is for moving if the smooth flag is set
            if (currentTracked != defaltTracked)
            {
                //this path expects start pos to be set using the start cinima call


                //this is the target tracked postion with the new z 
                

                //this is the thing messing it up
                //change the positon
                transform.position = Vector3.MoveTowards(transform.position, target, cammraSpeed * Time.deltaTime);
            }
        }
    }
    private void changeTracked(Transform newTracked)
    {
        currentTracked = newTracked;
    }
    //this is the start cinima where it gose to one tracked and then returns to defalt object
    public void StartCinimatic(float duration,Transform target)
    {
        //this sets the smoothflag
        smooth = true;
        changeTracked(target);
        startPos = new Vector3(transform.position.x, transform.position.y, cammraZ);
        StartCoroutine(MoveToLoc(duration,defaltTracked));
    }
    //has to be called as a coroutine
    public IEnumerator StartCinimatic(float duration,Transform[] targetList)
    {
        smooth = true;
        //loop through each transform in postion and move to them and wait untill done to triger next
        for (int i=0;i<targetList.Length;i++)
        {
            startPos = new Vector3(transform.position.x, transform.position.y, cammraZ);
            yield return StartCoroutine(MoveToLoc(duration, targetList[i]));
        }
        //this resets to player
        yield return StartCoroutine(endShot());
    }
    private IEnumerator MoveToLoc(float duration,Transform newTracked)
    {
        //wait untill the cammra is within range
        while(Vector2.Distance(transform.position, currentTracked.position) > closeDistence)
        {
            yield return null;
        }
        //hold the shot for duration
        yield return new WaitForSecondsRealtime(duration);
        yield return StartCoroutine(endShot());
    }
    private IEnumerator endShot()
    {
        Debug.Log("riddle me piss batman");
        changeTracked(defaltTracked);
        while (Vector2.Distance(transform.position, currentTracked.position) > closeDistence)
        {
            Debug.Log("falls");
            yield return null;
        }
        smooth = false;
    }
}
