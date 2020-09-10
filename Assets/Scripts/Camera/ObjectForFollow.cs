using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectForFollow : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        if(collision.gameObject.transform.position.y <= transform.position.y)
    //        {
    //            transform.position = new Vector3(transform.position.x, collision.gameObject.transform.position.y, transform.position.z);
    //            Debug.Log("123");
    //        }
    //    }
    //}

    public float smooth = 0.5f;
    public float offset;

    private Vector3 velocity;

    public Transform GetLowestBall
    {
        get
        {
            var lowest = (from t in WaterSpawner.Instance.objs orderby t.transform.position.y select t).ToList()[0];

            return lowest.transform;
        }
        set { }
    }

    private void LateUpdate()
    {
        if (GetLowestBall != null)
        {
            Vector3 vector = new Vector3(0f, GetLowestBall.position.y + offset, -15f);

            if (vector.y < transform.position.y)
            {
                transform.position = Vector3.SmoothDamp(transform.position,
                                                        vector,
                                                        ref velocity,
                                                        smooth);
            }
        }
    }

    //public float smooth = 0.5f;
    //public float offset;

    //private Vector3 velocity;

    //private GameObject GetLowestBall
    //{
    //    get => (from t in WaterSpawner.Instance.objs
    //            orderby t.transform.position.y
    //            select t
    //            ).ToList()[0];
    //}

    //private void LateUpdate()
    //{
    //    if (GetLowestBall != null)
    //    {
    //        Vector3 vector = new Vector3(0f, GetLowestBall.position.y + offset, -15f);

    //        if (vector.y < transform.position.y)
    //        {
    //            transform.position = Vector3.SmoothDamp(transform.position,
    //                                                    vector,
    //                                                    ref velocity,
    //                                                    smooth);
    //        }
    //    }
    //}
}
