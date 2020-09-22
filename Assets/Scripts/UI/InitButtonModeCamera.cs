using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitButtonModeCamera : MonoBehaviour
{
    //private void OnEnable()
    //{
    //    if(PlayerPrefs.GetString("camera") == "auto")
    //    {

    //    }
    //}

    public void SwapMode()
    {
        switch (PlayerPrefs.GetString("camera"))
        {
            case "auto":
                PlayerPrefs.SetString("camera", "slider");
                break;

            case "slider":
                PlayerPrefs.SetString("camera", "auto");
                break;
            default:
                PlayerPrefs.SetString("camera", "slider");
                break;
        }
    }
}
