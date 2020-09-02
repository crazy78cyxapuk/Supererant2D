using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRope : MonoBehaviour
{
    private LineRenderer line;

    [SerializeField] private Transform[] rope;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = rope.Length;
    }

    private void Update()
    {
        for (int i = 0; i < line.positionCount; i++)
        {
            line.SetPosition(i, rope[i].position);
        }
    }
}
