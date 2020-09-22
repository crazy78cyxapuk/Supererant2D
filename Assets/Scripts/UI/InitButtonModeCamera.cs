using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitButtonModeCamera : MonoBehaviour
{
    [SerializeField] private Sprite autoImg;
    [SerializeField] private Sprite sliderImg;

    private void OnEnable()
    {
        if (PlayerPrefs.GetString("camera") == "auto")
        {
            GetComponent<Image>().sprite = autoImg;
        }
        else
        {
            GetComponent<Image>().sprite = sliderImg;
        }
    }

    public void SwapMode()
    {
        switch (PlayerPrefs.GetString("camera"))
        {
            case "auto":
                PlayerPrefs.SetString("camera", "slider");
                GetComponent<Image>().sprite = sliderImg;
                break;

            case "slider":
                PlayerPrefs.SetString("camera", "auto");
                GetComponent<Image>().sprite = autoImg;
                break;
            default:
                PlayerPrefs.SetString("camera", "slider");
                GetComponent<Image>().sprite = sliderImg;
                break;
        }
    }
}
