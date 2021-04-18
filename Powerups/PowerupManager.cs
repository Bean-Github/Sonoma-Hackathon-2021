using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject[] powerups;
    public float timer;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Debug.Log("Spawn");
        StartCoroutine(SpawnPowerups());
    }

    private IEnumerator SpawnPowerups()
    {
        yield return new WaitForSeconds(timer);

        int targetPowerup;
        if (FindObjectsOfType<Bullet>().Length >= 8)
        {
            targetPowerup = 1;
        }
        else
        {
            targetPowerup = Random.Range(0, powerups.Length);
        }

        Instantiate(powerups[targetPowerup], new Vector3(0f, 0f), Quaternion.identity);
    }
}
