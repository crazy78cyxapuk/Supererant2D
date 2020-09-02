using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject water;
    [SerializeField] private Transform crane;
    [HideInInspector] public List<GameObject> objs = new List<GameObject>();

    [SerializeField] private Button spawnBtn;

    private int countWaters = 5;

    private ManagerPool managerPool = new ManagerPool();
    //private bool isSpawn = false;

    private void Start()
    {
        managerPool.AddPool(PoolType.Entities);
    }

    //private void Update()
    //{
    //    if (isSpawn == true)// && objs.Count < countWaters)
    //    {
    //        for (var i = 0; i < 1; i++)
    //        {
    //            objs.Add(managerPool.Spawn(PoolType.Entities, water, crane.transform.position));
    //            spawnBtn.text = (countWaters - objs.Count).ToString();
    //        }
    //    }

    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        for (var i = 0; i < objs.Count; i++)
    //        {
    //            managerPool.Despawn(PoolType.Entities, objs[i]);
    //        }
    //        objs.Clear();
    //    }
    //}

    public void Spawn()
    {
        StartCoroutine(SpawnWaitForSec());
    }

    IEnumerator SpawnWaitForSec()
    {
        spawnBtn.interactable = false;

        for(int i=0; i < countWaters; i++)
        {
            objs.Add(managerPool.Spawn(PoolType.Entities, water, crane.transform.position));
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(1.5f);

        spawnBtn.interactable = true;
    }
}
