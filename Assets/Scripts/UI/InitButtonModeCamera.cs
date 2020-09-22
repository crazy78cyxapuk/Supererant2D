using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitButtonModeCamera : MonoBehaviour
{
    private void OnEnable()
    {
        if(PlayerPrefs.GetString("camera") == "auto")
        {

        }
    }
}
