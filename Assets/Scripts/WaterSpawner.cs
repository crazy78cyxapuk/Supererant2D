using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WaterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject water;
    [SerializeField] private Transform crane;
    [HideInInspector] public List<GameObject> objs = new List<GameObject>();

    [SerializeField] private Button spawnBtn;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject slider;

    private int countWaters;

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
    }

    private void EnableCameraFollow()
    {
        mainCamera.GetComponent<CameraFollow>().enabled = true;
    }

    private void EnableSlider()
    {
        slider.SetActive(true);
    }

    public void Spawn()
    {
        countWaters = Random.Range(5, 16);

        StartCoroutine(SpawnWaitForSec());
    }

    IEnumerator SpawnWaitForSec()
    {
        spawnBtn.interactable = false;

        for(int i=0; i < countWaters; i++)
        {
            objs.Add(managerPool.Spawn(PoolType.Entities, water, crane.transform.position));

            float rand = Random.Range(150, 250) / 1000f;
            objs[objs.Count - 1].transform.localScale = new Vector3(rand, rand, rand);

            objs[objs.Count - 1].GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));

            yield return new WaitForSeconds(0.2f);
        }

        EnableCameraFollow();
        EnableSlider();

        yield return new WaitForSeconds(1.5f);

        spawnBtn.interactable = true;
    }
}
