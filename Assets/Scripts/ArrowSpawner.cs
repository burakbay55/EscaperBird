using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
  
    public GameObject arrows;

    //okların kac saniyede bir spawnlanacagi.
    public float timeBetweenSpawn;
    public float time;
    public GameObject ball;    
    void Start()
    {
        time = 0.0f;
    }

    public void spawner()
    {   
        Vector3 pos = new Vector3(12,ball.transform.position.y);
        Quaternion q = this.transform.rotation;

        Instantiate(arrows, pos, q);
    }

    
    void Update()
    {
        time += Time.deltaTime;
        if(time > timeBetweenSpawn)
        {
            if(ball != null)
            {
            spawner();
            time = 0;
            }
        }

       
        
        //zaman gectikce oklarin spawn hizi artar. 
        if(GameMode.time >= 10 && GameMode.time <= 20)
        {
            timeBetweenSpawn = 2.5f;
            ArrowBehaivour.arrowSpeed = 5.5f;
        }

        else if(GameMode.time > 20 && GameMode.time <= 30)
        {
            timeBetweenSpawn = 2f;
        }
        
        else if(GameMode.time > 30 && GameMode.time <= 40)
        {
            timeBetweenSpawn = 1.5f;
            ArrowBehaivour.arrowSpeed = 6f;
        }

        else if(GameMode.time > 40)
        {
           timeBetweenSpawn = 1f;
           ArrowBehaivour.arrowSpeed = 7f;
        }
    }

    
}
