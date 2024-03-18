using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _androidGameId;
    [SerializeField] private string _IOSGameId;
    [SerializeField] private bool _testMode;
    private string _gameId;

    private void Awake()
    {
        if (Advertisement.isInitialized)
        {
            return;
        }
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)? _IOSGameId : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }
    
    public void OnInitializationComplete()
    {
        Debug.Log("Ads init copmplete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Fail ads");
    }
}
