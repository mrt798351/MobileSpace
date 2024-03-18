using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    private string _adUnitId = null; // This will remain null for unsupported platforms

    [SerializeField] private GameObject player;
    [SerializeField] private BannerAd bannerAd;

    public int adNumber = 1;
    
    private void Awake()
    {   
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        
        LoadAd();
    }

    private void Start()
    {
        EndGameManager.endManager.RegisterRewardedAd(this);
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
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        EndGameManager.endManager.score = PlayerPrefs.GetInt("Score" + SceneManager.GetActiveScene().name);
        Advertisement.Banner.Hide();
        Time.timeScale = 0;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
        {
            Time.timeScale = 1;
            player.SetActive(true);
            bannerAd.LoadBannerAd();
            
            LoadAd();
        }
    }
}
