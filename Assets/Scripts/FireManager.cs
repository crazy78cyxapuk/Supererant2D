using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField] private GameObject GameMain, Finish;

    private int countFires;

    private static FireManager instance;
    public static FireManager Instance => instance;

    private void Awake()
    {
        InitSingleton();
    }

    private void InitSingleton()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Fire");
        countFires = obj.Length;
    }

    public void MinusFire()
    {
        countFires -= 1;
        if (countFires == 0)
        {
            EnableFinishScreen();
        }
    }

    private void EnableFinishScreen()
    {
        GameMain.SetActive(false);
        Finish.SetActive(true);
    }
}
