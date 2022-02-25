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
    .SetTestDeviceIds( new System.Collections.Generic.List<string>() { "" } )
    .build();
 
    MobileAds.SetRequestConfiguration( reklamKonfigurasyonu );
  
        MobileAds.Initialize(initStatus => {} );
        

        this.reklamObject = new BannerView("", AdSize.SmartBanner, AdPosition.Bottom);
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
