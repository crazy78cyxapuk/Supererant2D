using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private AudioSource music;

    [SerializeField] private GameObject musicObj;
    //[SerializeField] private GameObject soundObj;

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

        //obj = GameObject.FindGameObjectWithTag("Sound");

        //if(obj == null)
        //{
        //    obj = Instantiate(soundObj);
        //    music = obj.GetComponent<AudioSource>();
        //    music.volume = PlayerPrefs.GetFloat("sound");
        //    DontDestroyOnLoad(obj);
        //}
    }
}
