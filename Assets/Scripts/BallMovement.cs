using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class BallMovement : MonoBehaviour
{
    public float velocity = 200f;
    private Rigidbody2D body;
    private float timeRemaining = 3;
    public static bool IsGameOver = false;
    public AudioSource apronsound;
    private InterstitialAd reklam;
    private float time = 5f;
   
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        apronsound = GetComponent<AudioSource>();
        body.gravityScale = 0;
       
        MobileAds.Initialize(initStatus => {});
        
    }

    private void requestInterstitial()
    {
        reklam = new InterstitialAd("ca-app-pub-3940256099942544/1033173712");
        
        AdRequest adRequest = new AdRequest.Builder().Build();
        reklam.LoadAd(adRequest);

        this.reklam.OnAdClosed += HandleClose;

        if(this.reklam.IsLoaded())
        {
            this.reklam.Show();
        }
      
       
    }
    //reklami gosterdikten sonra yok etme.
    void HandleClose(object a, EventArgs args)
    {
      this.reklam.Destroy();
    }
     
    void Update()
    {
        //ilk uc saniye top yere dusmesin.
        if(timeRemaining>0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            body.gravityScale = 1;
        }
        
        //ekrana her dokunusta topa guc uygula.
        if(Input.touchCount==1 && GameMode.isPausedButton == false)
        {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(0, velocity));
        }
        
        //koruma kalkani aktif olunca gorunurlugu ac.
        if(apronController.isApron == true)
        {
           
           this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
           

             time -= Time.deltaTime;
             if(time <= 0)
             {
               apronController.isApron = false;
               this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
             }
        }

      
           
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(apronController.isApron == false)
        {
         if (collision.gameObject.CompareTag("Arrow"))
         {
            Destroy(this.gameObject);
            IsGameOver = true;
            requestInterstitial();

         }
         
        }

        if(collision.gameObject.CompareTag("Apron"))
        {
            apronsound.Play();
        }
        
    }
     
}
