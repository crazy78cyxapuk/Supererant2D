using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNameLvl : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(HideNameLvl());
    }

    IEnumerator HideNameLvl()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
