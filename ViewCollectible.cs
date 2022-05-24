using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCollectible : MonoBehaviour
{
 
    private Transform mainChar;
    public GameObject collCam;

    public float moveSpeed;
    public Transform me;
    public bool collClick = false;

    public Transform endMarker;
    //public Transform startMarker;
    private Vector3 scaleChange;

    public void Awake()
    {
        scaleChange = new Vector3(0.000f, 0.001f, 0.001f);
    }

    public void FindCollHolder()
    {       
        mainChar = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnMouseDown()
    {
  
        collCam.SetActive(true);
        collClick = true;

    }

    void Update()
    {
        var speed = moveSpeed;
        float step = speed * Time.deltaTime;

        if (collClick == true && me.transform.position != endMarker.position)
        {
        
            me.transform.position = Vector3.MoveTowards(me.transform.position, endMarker.position, step);
            me.transform.localScale += scaleChange;
            me.transform.LookAt(mainChar);

        }
        else
        {
            collClick = false;

        }

        if (collCam.activeSelf == true)
        {
            me.transform.Rotate(0.0f, 2.0f, 0.0f, Space.Self);
        }

      
    }
}
