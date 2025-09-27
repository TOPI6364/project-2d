using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string AndroidGameID;
    [SerializeField] string IOSGameID;
    string GameID;
    private string intId = "Interstitial_Android";
    private string rewId = "Rewarded_Android";
    private string bannerId = "Banner_Android";
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        Advertisement.Load(intId, this);
        Advertisement.Load(rewId, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals(intId))
        {
            Debug.Log("IntAdsLoaded");
        }
        if (placementId.Equals(rewId))
        {
            Debug.Log("RewAdsLoaded");
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        if (placementId.Equals(intId))
        {
            Debug.Log($"Unity IntAds Load Failed: {error.ToString()} - {message}");
        }

    }

    // Start is called before the first frame update
    void Awake()
    {
        GameID = (Application.platform == RuntimePlatform.IPhonePlayer)?IOSGameID : AndroidGameID;
        Advertisement.Initialize(GameID, true, this);
    }

    public void ShowAD()
    {
        Advertisement.Show(intId, this);
    }
 
    public void ShowRewardAd()
    {
        Advertisement.Show(rewId, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
 
    }

    public void OnUnityAdsShowStart(string placementId)
    {
 
    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(rewId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("тебе не чего не дали, хах");
            Advertisement.Load(rewId, this);
        }
    }

    private void Start()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerId);
    }

}
