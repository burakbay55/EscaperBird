using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCounter : MonoBehaviour
{
   
   private void OnTriggerEnter2D(Collider2D col)
   {
       if(col.name == "Circle")
       {
           GameMode.GameScore++;
           
       }
   }
}
