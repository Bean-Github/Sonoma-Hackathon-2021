using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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

        transform.right = Vector3.Reflect(transform.right, collision.GetContact(0).normal);
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play(bounceClip, 0.25f, 1f);
    }
}
