using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private AudioSource music;

    [SerializeField] private GameObject musicObj;

    private void Awake()
    {
        if(PlayerPrefs.GetFloat("enterInGame") == 0)
        {
            PlayerPrefs.SetFloat("music", 1);
            PlayerPrefs.SetFloat("enterInGame", 10);
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
    }
}
