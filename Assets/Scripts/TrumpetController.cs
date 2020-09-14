using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpetController : MonoBehaviour
{
    [SerializeField] private Transform exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HideGameObject(collision.gameObject);
        }
    }

    private void HideGameObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = exit.position;
        obj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        StartCoroutine(ShowGameObject(obj));
    }

    IEnumerator ShowGameObject(GameObject obj)
    {
        yield return new WaitForSeconds(1f);

        obj.SetActive(true);
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1, 2), Random.Range(-10, 0));
    }
}
