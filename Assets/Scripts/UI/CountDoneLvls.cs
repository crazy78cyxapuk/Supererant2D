using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDoneLvls : MonoBehaviour
{
    [SerializeField] private string nameLvl;
    [SerializeField] private int countLvl;

    private void OnEnable()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(nameLvl).ToString() + "/" + countLvl.ToString();
    }
}
