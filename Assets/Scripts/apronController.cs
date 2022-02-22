using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apronController : MonoBehaviour
{
    private Rigidbody2D apron;
    public static bool isApron = false;
    
    void Start()
    {
        apron = GetComponent<Rigidbody2D>();
        
    }

   
    void Update()
    {   
        //koruma kalkani hiz ve yok olma
        apron.velocity = new Vector2(-5f,0);
        if(this.transform.position.x < -13f)
        {
            Destroy(this.gameObject);
        }
        
        // bird yok oldugunda koruma kalkanini da yok et.
        if(BallMovement.IsGameOver == true)
        {
            Destroy(this.gameObject);
        }
       
    }
    
    //koruma kalkanina temas var mi?
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ball"))
        {
          isApron = true;
          Destroy(this.gameObject);
        }
    }
}
