﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{

    public GameObject platform;

    
    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPosition;

    bool stop;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;  

        StartCoroutine(spawnPlatforms());  
    }

    // Update is called once per frame
    void Update()
    {

    }

IEnumerator spawnPlatforms()
{
        while(!stop)
        {
        generatePosition();

        Instantiate(platform, newPosition, Quaternion.identity);
        
        lastPosition = newPosition;

        yield return new WaitForSeconds(0.1f);
        }

}


    // void spawnPlatform()
    // {
    //     generatePosition();

    //     Instantiate(platform,newPosition,Quaternion.identity);
        
    //     lastPosition = newPosition;

    // }

    void generatePosition()
    {
        newPosition=lastPosition;

        int rand = Random.Range(0,2);

        if(rand > 0)
            newPosition.x += 2f;
        else
            newPosition.z += 2f;

    }

}
