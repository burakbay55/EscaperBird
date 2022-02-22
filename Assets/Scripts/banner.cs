using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class banner : MonoBehaviour
{
    private BannerView reklamObject;
    void Start()
    {
        RequestConfiguration reklamKonfigurasyonu = new RequestConfiguration.Builder()
    .SetTestDeviceIds( new System.Collections.Generic.List<string>() { "1cb8d73d" } )
    .build();
 
    MobileAds.SetRequestConfiguration( reklamKonfigurasyonu );
  
        MobileAds.Initialize(initStatus => {} );
        

        this.reklamObject = new BannerView("ca-app-pub-3940256099942544/6300978111", AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest requestBanner = new AdRequest.Builder().Build();
        this.reklamObject.LoadAd(requestBanner);
    }

    void OnDestroy()
    {
        if(reklamObject != null)
        {
            reklamObject.Destroy();
        }
    }

    
}
