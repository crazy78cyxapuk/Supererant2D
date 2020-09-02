using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 dir;
    private Vector2 lastVelocity;

    [SerializeField] private TrajectoryRenderer trajectoryRenderer;

    #region PushWater

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    float pushForce = 4f;

    private Camera cam;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ricochet"))
        {
            var speed = lastVelocity.magnitude;
            var dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = dir * Mathf.Max(speed, 0f);
        }
    }

    private void OnMouseDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        trajectoryRenderer.UpdateDots(transform.position, force);
    }

    private void OnMouseUp()
    {
        rb.AddForce(force, ForceMode2D.Impulse);

        trajectoryRenderer.Hide();  
    }

    private void OnMouseDown()
    {
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectoryRenderer.Show();


    }
}
