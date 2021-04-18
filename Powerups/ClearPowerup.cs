using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPowerup : MonoBehaviour
{
    public void ClearBullets()
    {
        foreach (Bullet bullet in FindObjectsOfType<Bullet>())
        {
            if (GetComponent<Powerup>().otherPlayer.playerNumber == "1")
            {
                if (bullet.transform.position.x < 0f)
                    Destroy(bullet.gameObject);
            }
            else
            {
                if (bullet.transform.position.x > 0f)
                    Destroy(bullet.gameObject);
            }
        }

        foreach (Largeball ball in FindObjectsOfType<Largeball>())
        {
            if (GetComponent<Powerup>().otherPlayer.playerNumber == "1")
            {
                if (ball.transform.position.x < 0f)
                    Destroy(ball.gameObject);
            }
            else
            {
                if (ball.transform.position.x > 0f)
                    Destroy(ball.gameObject);
            }
        }
    }
}
