using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLPFEnter : MonoBehaviour
{
    public Transform player;
    public Transform inHouse;
    public float dist;
    public float howClose;
    AudioLowPassFilter aLPF;


    void Awake()
    {
        aLPF = GetComponent<AudioLowPassFilter>();
        aLPF.enabled = false;
    }

    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    
        inHouse = GameObject.FindGameObjectWithTag("Inside").transform;
    }


    void Update()
    {
        dist = Vector3.Distance(player.position, inHouse.position);

        if (dist <= howClose && dist >= 3)
        {
            aLPF.enabled = true;
            aLPF.cutoffFrequency = (dist * 700);
        } else if (dist <= 5) {
            aLPF.enabled = true;
            aLPF.cutoffFrequency = 2000;
        } else
        {
            aLPF.enabled = false;
        }
    }

    }
