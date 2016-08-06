using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour {
    public static AdManager Instance { set; get; }
    public string videoAd;
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-6044705985167929/9665428898";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-6044705985167929/9665428898";
#else
        string adUnitId = "unexpected_platform";
#endif

        AdRequest request = new AdRequest.Builder()
        .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        // My test device.
        .Build();


        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void ShowBanner()
    {
        
    }

    public void ShowVideo()
    {
       

    }
}
