using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockLvl : MonoBehaviour
{
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("forest") + PlayerPrefs.GetInt("urban") + PlayerPrefs.GetInt("suburban") + PlayerPrefs.GetInt("village") + PlayerPrefs.GetInt("desert") + PlayerPrefs.GetInt("midtown") == 51)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
