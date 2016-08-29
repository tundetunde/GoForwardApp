using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour {
    public static AdManager Instance { set; get; }
    public string videoAd;
    BannerView bannerView;
    InterstitialAd fullScreenAd;
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-6044705985167929/9665428898";
        string InterstitiaId = "ca-app-pub-6044705985167929/2142162092";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-6044705985167929/9665428898";
        string InterstitiaId = "ca-app-pub-6044705985167929/2142162092";
#else
        string adUnitId = "unexpected_platform";
#endif

        AdRequest request = new AdRequest.Builder()
        .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        // My test device.
        .Build();


        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.TopLeft);
        fullScreenAd = new InterstitialAd(InterstitiaId);
        // Load the banner with the request.
        bannerView.LoadAd(request);
        fullScreenAd.LoadAd(request);
        
    }

    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void ShowFullScreenAds()
    {
        int fullAds = PlayerPrefs.GetInt("FullScreenAds", 1);
        PlayerPrefs.SetInt("FullScreenAds", ++fullAds);
        if (fullAds >= 3)
        {
            PlayerPrefs.SetInt("FullScreenAds", 0);
            fullScreenAd.Show();
        }

    }
}
