using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPowerup : MonoBehaviour
{
    public GameObject wall;
    private GameObject createdWall;

    public void BuildWall()
    {
        Player player = GetComponent<Powerup>().otherPlayer;
        createdWall = Instantiate(wall, player.transform.position + player.transform.right, player.transform.rotation);
        StartCoroutine(DestroyWall());
    }

    public IEnumerator DestroyWall()
    {
        yield return new WaitForSeconds(15f);
        Destroy(createdWall);
    }
}
