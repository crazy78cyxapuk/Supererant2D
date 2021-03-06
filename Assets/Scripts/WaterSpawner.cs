﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WaterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject water;
    [SerializeField] private Transform crane;
    [HideInInspector] public List<GameObject> objs = new List<GameObject>();

    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject slider;

    private int countWaters;
    private int countWatersForRestart;

    private ManagerPool managerPool = new ManagerPool();

    private static WaterSpawner instance;
    public static WaterSpawner Instance => instance;

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
        managerPool.AddPool(PoolType.Entities);

        Spawn();
    }

    private void EnableCameraFollow()
    {
        mainCamera.GetComponent<CameraFollow>().enabled = true;
    }

    private void EnableSlider()
    {
        if (mainCamera.transform.position.y != CameraFollow.Instance.minPositionY)
        {
            slider.SetActive(true);
        }
    }

    private void Spawn()
    {
        countWaters = Random.Range(5, 16);
        countWatersForRestart = countWaters;

        StartCoroutine(SpawnWaitForSec());
    }

    IEnumerator SpawnWaitForSec()
    {
        yield return new WaitForSeconds(3f);

        for(int i=0; i < countWaters; i++)
        {
            objs.Add(managerPool.Spawn(PoolType.Entities, water, crane.transform.position));

            float rand = Random.Range(150, 250) / 1000f;
            objs[objs.Count - 1].transform.localScale = new Vector3(rand, rand, rand);

            objs[objs.Count - 1].GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));

            objs[objs.Count - 1].transform.position = new Vector3(objs[objs.Count - 1].transform.position.x, objs[objs.Count - 1].transform.position.y, -10f);

            yield return new WaitForSeconds(0.2f);
        }


        EnableCameraFollow();
        EnableSlider();
    }

    public void FinishShowRewards()
    {
        StartCoroutine(SecondSpawn());
    }

    IEnumerator SecondSpawn()
    {
        yield return new WaitForSeconds(3f);

        for(int i=0; i<countWaters; i++)
        {
            managerPool.Despawn(PoolType.Entities, objs[i]);
        }

        for (int i = 0; i < countWaters; i++)
        {
            objs.Add(managerPool.Spawn(PoolType.Entities, water, crane.transform.position));

            float rand = Random.Range(150, 250) / 1000f;
            objs[objs.Count - 1].transform.localScale = new Vector3(rand, rand, rand);

            objs[objs.Count - 1].GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));

            objs[objs.Count - 1].transform.position = new Vector3(objs[objs.Count - 1].transform.position.x, objs[objs.Count - 1].transform.position.y, -10f);

            yield return new WaitForSeconds(0.2f);
        }
    }

    public void Restart(GameObject obj)
    {
        //countWatersForRestart--;

        //if (countWatersForRestart <= 0)
        //{
        //    TransitionsMenu.Instance.TransitionScene(FireManager.Instance.nameLvl);
        //}

        managerPool.Despawn(PoolType.Entities, obj);
        objs.Remove(obj);

        if (objs.Count <= 0)
        {
            TransitionsMenu.Instance.TransitionScene(FireManager.Instance.nameLvl);
        }
    }
}
