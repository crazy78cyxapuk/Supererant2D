using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using GoogleMobileAds.Api;

public class Ads : MonoBehaviour
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

    [SerializeField] private Text txt; 

    private string appKey = "ca-app-pub-5922323158220499~7700909397";

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewarded;

    private string idBanner = "ca-app-pub-5922323158220499/1101526239";
    private string idInterstitial = "ca-app-pub-5922323158220499/5429969279";
    private string idReward = "ca-app-pub-5922323158220499/5952713454";

    private void Start()
    {
        MobileAds.Initialize(appKey);

        LoadInterstitial();
        LoadReward();
    }

    #region Appodeal
    //private void Initialize(bool isTesting)
    //{
    //    Appodeal.setTesting(isTesting);
    //    Appodeal.disableLocationPermissionCheck();
    //    Appodeal.disableWriteExternalStoragePermissionCheck();
    //    Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO | Appodeal.BANNER);
    //}

    //public void ShowBanner()
    //{
    //    if (Appodeal.isLoaded(Appodeal.BANNER))
    //    {
    //        Appodeal.show(Appodeal.BANNER_BOTTOM);
    //    }
    //}

    //public void HideBanner()
    //{
    //    Appodeal.hide(Appodeal.BANNER);
    //}

    //public void ShowInterstitial()
    //{
    //    if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
    //    {
    //        Appodeal.show(Appodeal.INTERSTITIAL);
    //    }
    //}

    //public IEnumerator IEShowNonSkippable()
    //{
    //    yield return new WaitUntil(() => Appodeal.canShow(Appodeal.NON_SKIPPABLE_VIDEO));
    //    Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
    //}

    //#region ListenerNonSkip
    //public void onNonSkippableVideoLoaded(bool isPrecache)
    //{
        
    //}

    //public void onNonSkippableVideoFailedToLoad()
    //{
    //    NonSkipClosedAds();
    //}

    //public void onNonSkippableVideoShowFailed()
    //{
    //    NonSkipClosedAds();
    //}

    //public void onNonSkippableVideoShown()
    //{
        
    //}

    //public void onNonSkippableVideoFinished()
    //{
    //    NonSkipFinishAds();
    //}

    //public void onNonSkippableVideoClosed(bool finished)
    //{
    //    NonSkipClosedAds();
    //}

    //public void onNonSkippableVideoExpired()
    //{
    //    NonSkipClosedAds();
    //}

    //#endregion

    //#region ListenerInterstitial
    //public void onInterstitialLoaded(bool isPrecache)
    //{
    //    //реклама загружена, тру - реклама прекеширована
    //}

    //public void onInterstitialFailedToLoad()
    //{
    //    FireManager.Instance.EnableFinishScreen();
    //}

    //public void onInterstitialShowFailed()
    //{
    //    FireManager.Instance.EnableFinishScreen();
    //}

    //public void onInterstitialShown()
    //{
    //    //throw new NotImplementedException();
    //}

    //public void onInterstitialClosed()
    //{
    //    FireManager.Instance.EnableFinishScreen();
    //}

    //public void onInterstitialClicked()
    //{
    //    //throw new NotImplementedException();
    //}

    //public void onInterstitialExpired()
    //{
    //    //throw new NotImplementedException();
    //}

    //#endregion

    //#region Methods after ads

    //private void NonSkipFinishAds()
    //{
    //    WaterSpawner.Instance.FinishShowRewards();
    //}

    //private void NonSkipClosedAds()
    //{
    //    TransitionsMenu.Instance.TransitionScene(FireManager.Instance.nameLvl);
    //}

    //#endregion

    #endregion

    public void ShowBanner()
    {
        bannerView = new BannerView(idBanner, AdSize.Banner, AdPosition.Bottom);
    }

    public void HideBanner()
    {
        bannerView.Destroy();
    }

    public void LoadInterstitial()
    {
        interstitial = new InterstitialAd(idInterstitial);

        interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        interstitial.Destroy();

        interstitial.OnAdClosed -= HandleOnAdClosed;
    }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void LoadReward()
    {
        rewarded = new RewardedAd(idReward);

        rewarded.OnUserEarnedReward += HandleUserEarnedReward;
        rewarded.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        rewarded.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;

        AdRequest request = new AdRequest.Builder().Build();
        rewarded.LoadAd(request);
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {

        txt.text = "HandleRewardedAdFailedToShow event received with message: " + args.Message;

        rewarded.OnUserEarnedReward -= HandleUserEarnedReward;
        rewarded.OnAdFailedToShow -= HandleRewardedAdFailedToShow;
        rewarded.OnAdFailedToLoad -= HandleRewardedAdFailedToLoad;
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        txt.text = "HandleRewardedAdFailedToLoad event received with message: " + args.Message;

        rewarded.OnUserEarnedReward -= HandleUserEarnedReward;
        rewarded.OnAdFailedToShow -= HandleRewardedAdFailedToShow;
        rewarded.OnAdFailedToLoad -= HandleRewardedAdFailedToLoad;
    }

    public void ShowReward()
    {
        if (rewarded.IsLoaded())
        {
            rewarded.Show();
        }
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        WaterSpawner.Instance.FinishShowRewards();

        rewarded.OnUserEarnedReward -= HandleUserEarnedReward;
        rewarded.OnAdFailedToShow -= HandleRewardedAdFailedToShow;
        rewarded.OnAdFailedToLoad -= HandleRewardedAdFailedToLoad;
    }

}
