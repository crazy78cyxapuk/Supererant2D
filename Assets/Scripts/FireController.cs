﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.SetActive(false);

            Debug.Log(gameObject.name);

            FireManager.Instance.MinusFire();
        }
    }
}
