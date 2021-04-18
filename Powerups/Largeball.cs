using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Largeball : MonoBehaviour
{
    public float speed;
    public AudioClip bounceClip;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player otherPlayer = collision.gameObject.GetComponent<Player>();
            otherPlayer.Die();
        }

        if (collision.gameObject.layer == 9)
        {
            if (transform.localScale != new Vector3(3f, 3f, 3f))
            {
                transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
                Destroy(collision.gameObject);
                return;
            }
        }

        transform.right = Vector3.Reflect(transform.right, collision.GetContact(0).normal);
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play(bounceClip, 0.25f, 1f);
    }
}