using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitAutoTransitionsScene : MonoBehaviour
{
    [SerializeField] private Sprite autoImg;
    [SerializeField] private Sprite manuallyImg;

    private void OnEnable()
    {
        if (PlayerPrefs.GetString("transitions") == "auto") //auto/manually
        {
            GetComponent<Image>().sprite = autoImg;
        }
        else
        {
            GetComponent<Image>().sprite = manuallyImg;
        }
    }

    public void SwapMode()
    {
        switch (PlayerPrefs.GetString("transitions"))
        {
            case "auto":
                PlayerPrefs.SetString("transitions", "manually");
                GetComponent<Image>().sprite = manuallyImg;
                break;

            case "manually":
                PlayerPrefs.SetString("transitions", "auto");
                GetComponent<Image>().sprite = autoImg;
                break;
            default:
                PlayerPrefs.SetString("transitions", "manually");
                GetComponent<Image>().sprite = manuallyImg;
                break;
        }
    }
}
