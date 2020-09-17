using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitMusic : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private string audio;

    private GameObject musicObj, soundObj;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(audio);
    }

    public void ListenerValue()
    {
        if(audio == "music")
        {
            if(musicObj == null)
            {
                musicObj = GameObject.FindGameObjectWithTag("MusicBackground");
            }

            musicObj.GetComponent<AudioSource>().volume = slider.value;
        }
        else
        {
            //sound
        }

        PlayerPrefs.SetFloat(audio, slider.value);
    }
}
