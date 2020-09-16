using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * moveSpeed));
    }
}
