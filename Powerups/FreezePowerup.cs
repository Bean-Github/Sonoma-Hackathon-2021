using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePowerup : MonoBehaviour
{
    float originalSpeed;
    float originalBallSpeed;

    public void Freeze()
    {
        if (FindObjectsOfType<Bullet>().Length != 0)
        {
            Bullet bullet = FindObjectOfType<Bullet>();
            if (bullet.speed != 0)
            {
                originalSpeed = bullet.speed;
            }
        }

        if (FindObjectsOfType<Largeball>().Length != 0)
        {
            Largeball ball = FindObjectOfType<Largeball>();
            if (ball.speed != 0)
            {
                originalBallSpeed = ball.speed;
            }
        }

        StartCoroutine(FreezeAndResume());
    }

    private IEnumerator FreezeAndResume()
    {
        foreach (Bullet bullet in FindObjectsOfType<Bullet>())
        {
            if (GetComponent<Powerup>().otherPlayer.playerNumber == "1")
            {
                if (bullet.transform.position.x < 0f)
                    bullet.speed = 0;
            }
            else
            {
                if (bullet.transform.position.x > 0f)
                    bullet.speed = 0;
            }
        }

        foreach (Largeball ball in FindObjectsOfType<Largeball>())
        {
            if (GetComponent<Powerup>().otherPlayer.playerNumber == "1")
            {
                if (ball.transform.position.x < 0f)
                    ball.speed = 0;
            }
            else
            {
                if (ball.transform.position.x > 0f)
                    ball.speed = 0;
            }
        }

            yield return new WaitForSeconds(10f);

        foreach (Bullet bullet in FindObjectsOfType<Bullet>())
        {
            if (GetComponent<Powerup>().otherPlayer.playerNumber == "1")
            {
                if (bullet.transform.position.x < 0f)
                    bullet.speed = originalSpeed;
            }
            else
            {
                if (bullet.transform.position.x > 0f)
                    bullet.speed = originalSpeed;
            }
        }

        foreach (Largeball ball in FindObjectsOfType<Largeball>())
        {
            if (GetComponent<Powerup>().otherPlayer.playerNumber == "1")
            {
                if (ball.transform.position.x < 0f)
                    ball.speed = originalBallSpeed;
            }
            else
            {
                if (ball.transform.position.x > 0f)
                    ball.speed = originalBallSpeed;
            }
        }
    }
}
