using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 dir;
    private Vector2 lastVelocity;

    private TrajectoryRenderer trajectoryRenderer;

    #region PushWater

    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private Vector2 force;
    private float distance;
    private float pushForce = 4f;

    private bool isPush = false;

    private Camera cam;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        trajectoryRenderer = GameObject.FindGameObjectWithTag("TrajectoryRenderer").GetComponent<TrajectoryRenderer>();
    }

    private void Update()
    {
        lastVelocity = rb.velocity;

        Debug.Log(isPush);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ricochet"))
        {
            var speed = lastVelocity.magnitude;
            var dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = dir * Mathf.Max(speed, 0f);
        }

        if (collision.gameObject.CompareTag("ForceWater"))
        {
            isPush = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ForceWater"))
        {
            force = new Vector2(0, 0);
            trajectoryRenderer.Hide();
            isPush = false;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("ForceWater"))
    //    {
    //        isPush = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("ForceWater"))
    //    {
    //        force = new Vector2(0, 0);
    //        trajectoryRenderer.Hide();
    //        isPush = false;
    //    }
    //}

    private void OnMouseDrag()
    {
        if (isPush == true)
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            distance = Vector2.Distance(startPoint, endPoint);
            direction = (startPoint - endPoint).normalized;
            force = direction * distance * pushForce;

            trajectoryRenderer.UpdateDots(transform.position, force);
        }
    }

    private void OnMouseUp()
    {
        if(isPush == true)
        {
            rb.AddForce(force, ForceMode2D.Impulse);

            trajectoryRenderer.Hide();
        }
    }

    private void OnMouseDown()
    {
        if (isPush == true)
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

            trajectoryRenderer.Show();
        }
    }
}
