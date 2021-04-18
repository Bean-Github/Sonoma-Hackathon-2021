using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Powerup : MonoBehaviour
{
    public UnityEvent UsePowerup;
    public AudioClip powerupClip;
    private int numOfCollisions = 0;

    [HideInInspector()]
    public Player otherPlayer;

    private PowerupManager powerupManager;

    private void Start()
    {
        powerupManager = GameObject.Find("Powerup Manager").GetComponent<PowerupManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (numOfCollisions == 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                otherPlayer = other.GetComponent<Player>();

                otherPlayer.ChangePowerup(this);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;

                powerupManager.Spawn();
                Debug.Log("SPawned");
                GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play(powerupClip, 0.5f, 1f);
            }
            numOfCollisions += 1;
        }
    }
}
