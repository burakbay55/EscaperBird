using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apron : MonoBehaviour
{
    public GameObject apron;
    
    private void apronSpawner()
    {
       Vector3 pos = new Vector3 (12,Random.Range(-4.5f,4.5f));
       Quaternion q = this.transform.rotation;

       Instantiate(apron,pos,q);

       
    }

    void Start()
    {
      Invoke("apronSpawner",Random.Range(17f,30f));
    }
    


    

   
}
