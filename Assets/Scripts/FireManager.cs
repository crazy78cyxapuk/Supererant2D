using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField] private GameObject GameMain, Finish;

    //private int countFires;
    private List<GameObject> fires = new List<GameObject>();

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

        for(int i=0; i<obj.Length; i++)
        {
            fires.Add(obj[i]);
        }
    }

    public void MinusFire(GameObject obj)
    {
        fires.Remove(obj);
        if(fires.Count == 0)
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
