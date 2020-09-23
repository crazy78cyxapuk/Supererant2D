using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockLvl : MonoBehaviour
{
    [SerializeField] private string nameCheckLvl;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(nameCheckLvl) != 1)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
