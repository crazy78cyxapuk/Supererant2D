using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Vector2 position = transform.position;
        //Vector2 targetPosition = collision.transform.position;
        //Vector2 direction = targetPosition - position;
        //direction.Normalize();
        //int moveSpeed = 10;
        //collision.transform.position += (Vector2)(direction * moveSpeed * Time.deltaTime);

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 500 * Time.deltaTime);
        }
    }
}
