using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Localization : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private string[] translateEN;
    [SerializeField] private string[] translateRU;

    private void OnEnable()
    {
        if (PlayerPrefs.GetString("localization") == "en")
        {
            InitTranslateEN();
        }
        else                              //когда будет много языков, то удобнее сделать через switch!!!!!!!!
        {
            InitTranslateRU();
        }
    }

    private void InitTranslateEN()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].SetText(translateEN[i]);
        }
    }

    private void InitTranslateRU()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].SetText(translateRU[i]);
        }
    }

    public void SwapTranslate()
    {
        switch (PlayerPrefs.GetString("localization"))
        {
            case "en":
                Debug.Log("en");
                PlayerPrefs.SetString("localization", "ru");
                InitTranslateRU();
                break;

            case "ru":
                Debug.Log("ru");
                PlayerPrefs.SetString("localization", "en");
                InitTranslateEN();
                break;
        }
    }
}
