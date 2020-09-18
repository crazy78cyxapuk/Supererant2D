using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(HideFire());
        }
    }

    IEnumerator HideFire()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sound");
        GetComponent<AudioSource>().Play();

        FireManager.Instance.MinusFire(gameObject);

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = null;

        yield return new WaitForSeconds(0.6f);
        gameObject.SetActive(false);
    }
}
