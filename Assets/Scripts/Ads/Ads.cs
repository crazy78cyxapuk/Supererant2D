using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class Ads : MonoBehaviour, INonSkippableVideoAdListener, IInterstitialAdListener
{
    #region SINGLETONE

    private static Ads instance;
    public static Ads Instance => instance;

    private void Awake()
    {
        InitSingleton();
    }

    private void InitSingleton()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    #endregion

    private string appKey = "a1c54eeb2980a29ba46742c08f4e42bcbcf7705ba80963ec";

    private void Start()
    {
        Initialize(true);
    }

    private void Initialize(bool isTesting)
    {
        Appodeal.setTesting(isTesting);
        Appodeal.disableLocationPermissionCheck();
        Appodeal.disableWriteExternalStoragePermissionCheck();
        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO | Appodeal.BANNER);
    }

    public void ShowBanner()
    {
        if (Appodeal.isLoaded(Appodeal.BANNER))
        {
            Appodeal.show(Appodeal.BANNER_BOTTOM);
        }
    }

    public void HideBanner()
    {
        Appodeal.hide(Appodeal.BANNER);
    }

    public void ShowInterstitial()
    {
        if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
        {
            Appodeal.show(Appodeal.INTERSTITIAL);
        }
    }

    public IEnumerator IEShowNonSkippable()
    {
        yield return new WaitUntil(() => Appodeal.canShow(Appodeal.NON_SKIPPABLE_VIDEO));
        Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
    }

    #region ListenerNonSkip
    public void onNonSkippableVideoLoaded(bool isPrecache)
    {
        
    }

    public void onNonSkippableVideoFailedToLoad()
    {
        NonSkipClosedAds();
    }

    public void onNonSkippableVideoShowFailed()
    {
        NonSkipClosedAds();
    }

    public void onNonSkippableVideoShown()
    {
        
    }

    public void onNonSkippableVideoFinished()
    {
        NonSkipFinishAds();
    }

    public void onNonSkippableVideoClosed(bool finished)
    {
        NonSkipClosedAds();
    }

    public void onNonSkippableVideoExpired()
    {
        NonSkipClosedAds();
    }

    #endregion

    #region ListenerInterstitial
    public void onInterstitialLoaded(bool isPrecache)
    {
        //реклама загружена, тру - реклама прекеширована
    }

    public void onInterstitialFailedToLoad()
    {
        FireManager.Instance.EnableFinishScreen();
    }

    public void onInterstitialShowFailed()
    {
        FireManager.Instance.EnableFinishScreen();
    }

    public void onInterstitialShown()
    {
        //throw new NotImplementedException();
    }

    public void onInterstitialClosed()
    {
        FireManager.Instance.EnableFinishScreen();
    }

    public void onInterstitialClicked()
    {
        //throw new NotImplementedException();
    }

    public void onInterstitialExpired()
    {
        //throw new NotImplementedException();
    }

    #endregion

    #region Methods after ads

    private void NonSkipFinishAds()
    {
        WaterSpawner.Instance.FinishShowRewards();
    }

    private void NonSkipClosedAds()
    {
        TransitionsMenu.Instance.TransitionScene(FireManager.Instance.nameLvl);
    }

    #endregion
}
