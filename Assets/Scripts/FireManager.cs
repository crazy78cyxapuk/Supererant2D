using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [HideInInspector] public int countFires;

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

        Debug.Log(countFires);
    }

    public void MinusFire()
    {
        countFires--;
        Debug.Log(countFires);
        if (countFires < 0)
        {
            //Time.timeScale = 0f;
        }
    }
}
