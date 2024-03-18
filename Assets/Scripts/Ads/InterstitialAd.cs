using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    [SerializeField] private BannerAd _bannerAd;
    private string _adUnitId;
    [SerializeField] private int _timeToSkip = 1;
 
    private void Awake()
    {
        // // Get the Ad Unit ID for the current platform:
        // _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
        //     ? _iOsAdUnitId
        //     : _androidAdUnitId;
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        int skipNumber = PlayerPrefs.GetInt("Interstitial", _timeToSkip);
        if (skipNumber != 0)
        {
            skipNumber -= 1;
            PlayerPrefs.SetInt("Interstitial", skipNumber);
        }
        else
        {
            LoadAd();
            PlayerPrefs.SetInt("Interstitial", _timeToSkip);
        }
    }

    public void LoadAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(_adUnitId, this);
        }
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
    }
    
    public void OnUnityAdsAdLoaded(string placementId)
    {
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Show Fail");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Show Start");
        Advertisement.Banner.Hide();
        Time.timeScale = 0;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Show Complete");
        Time.timeScale = 1;
        _bannerAd.LoadBannerAd();
    }
}
