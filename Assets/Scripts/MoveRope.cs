using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRope : MonoBehaviour
{
    [SerializeField] private float strengthForce;

    //private Vector3 firstPosition;
    private Vector3 lastClick;
    private Vector3 direction;
    private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D[] allRope;

    private List<Rigidbody2D> balls = new List<Rigidbody2D>();

    private float maxStrengthRope = 2.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseUp()
    {
        if (balls.Count > 0)
        {
            Vector2 dir = new Vector2(0, strengthForce * balls.Count);

            for(int i=0; i < allRope.Length; i++)
            {
                allRope[i].AddForce(dir, ForceMode2D.Impulse);
            }

            //rb.AddForce(dir, ForceMode2D.Impulse);
        }
    }

    private void OnMouseDown()
    {
        //firstPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        lastClick = Input.mousePosition;
        lastClick = Camera.main.ScreenToWorldPoint(lastClick);
        MoveObject();
    }

    private void MoveObject()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouse - transform.position);
        if(direction.y > maxStrengthRope)
        {
            direction.y = maxStrengthRope;
        }
        if(direction.y < -maxStrengthRope)
        {
            direction.y = -maxStrengthRope;
        }
        rb.velocity = new Vector2(direction.x, direction.y) * 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            balls.Add(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            balls.Remove(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }
}
