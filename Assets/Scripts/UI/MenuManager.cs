using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private AudioSource music;

    [SerializeField] private GameObject musicObj;

    [SerializeField] private GameObject adsObject;

    private void Awake()
    {
        if (PlayerPrefs.GetFloat("enterInGame") != 10)
        {
            PlayerPrefs.SetFloat("music", 1); //музыка
            PlayerPrefs.SetFloat("sound", 1); //звуки
            PlayerPrefs.SetString("localization", "en"); //локализация
            PlayerPrefs.SetString("camera", "slider"); //камера в игре //slider/auto
            PlayerPrefs.SetString("transitions", "auto"); //переходы между уровнями //auto/manually
            PlayerPrefs.SetFloat("enterInGame", 10); //обозначаем, что игрок уже заходил в игру
        }

        InitVolumeMusic();

        //InitAds();

        //Ads.Instance.ShowBanner();
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
    }
}
