using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaivour : MonoBehaviour
{
    public static float arrowSpeed = 5f;
    private Rigidbody2D body;
   

    void Start()
    {
      body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      body.velocity = new Vector2(-arrowSpeed,0);

     if(this.transform.position.x < -13f)
      {
        Destroy(this.gameObject);
      }
    }
    
    // koruma kalkani aktif iken oka temas var ise oku yok et.
    void OnCollisionEnter2D(Collision2D col)
    {
      if(apronController.isApron == true)
      {
        Destroy(this.gameObject);
      }
    }
    
}
