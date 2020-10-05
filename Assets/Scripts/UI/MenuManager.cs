using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private AudioSource music;

    [SerializeField] private GameObject musicObj;

    [SerializeField] private GameObject adsObject;

    [SerializeField] private GameObject TitleScreen;
    [SerializeField] private GameObject PrivacyScreen;

    private void Awake()
    {
        if (PlayerPrefs.GetFloat("enterInGame") != 10)
        {
            PrivacyScreen.SetActive(true);

            PlayerPrefs.SetFloat("music", 1); //музыка
            PlayerPrefs.SetFloat("sound", 1); //звуки
            PlayerPrefs.SetString("localization", "en"); //локализация
            PlayerPrefs.SetString("camera", "slider"); //камера в игре //slider/auto
            PlayerPrefs.SetString("transitions", "auto"); //переходы между уровнями //auto/manually
            PlayerPrefs.SetFloat("enterInGame", 10); //обозначаем, что игрок уже заходил в игру
        }
        else
        {
            TitleScreen.SetActive(true);

            InitAds();
        }

        InitVolumeMusic();
    }

    public void AgreePolicy()
    {
        InitAds();

        TitleScreen.SetActive(true);
        PrivacyScreen.SetActive(false);
    }

    public void DisagreePolicy()
    {
        Application.Quit();
    }

    private void InitVolumeMusic()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("MusicBackground");

        if (obj == null)
        {
            obj = Instantiate(musicObj);
            music = obj.GetComponent<AudioSource>();
            music.volume = PlayerPrefs.GetFloat("music");
            DontDestroyOnLoad(obj);
        }
    }

    private void InitAds()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Ads");

        if (obj == null)
        {
            obj = Instantiate(adsObject);
            DontDestroyOnLoad(obj);
        }

        Ads.Instance.ShowBanner();
    }
}
