using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeballPowerup : MonoBehaviour
{
    public GameObject largeBall;

    public void CreateBall()
    {
        Transform player = GameObject.Find(GetComponent<Powerup>().otherPlayer.name).transform;

        Instantiate(
            largeBall,
            player.position + player.transform.right,
            player.transform.rotation
        );
    }
}
