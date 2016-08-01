using UnityEngine;
using System.Collections;
using admob;

public class AdManager : MonoBehaviour {
    public static AdManager Instance { set; get; }
    public string bannerId;
    public string videoAd;
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        #if UNITY_EDITOR
        #elif UNITY_ANDROID
            Admob.Instance().initAdmob(bannerId, videoAd);
            Admob.Instance().loadInterstitial();
            Admob.Instance().setTesting(true);
        #endif

    }

    public void ShowBanner()
    {
        #if UNITY_EDITOR
        #elif UNITY_ANDROID
            Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 5);
        #endif
    }

    public void ShowVideo()
    {
        #if UNITY_EDITOR
            if (Admob.Instance().isInterstitialReady())
                Admob.Instance().showInterstitial();
        #elif UNITY_ANDROID
        #endif

    }
}
