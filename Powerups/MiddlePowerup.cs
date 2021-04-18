using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePowerup : MonoBehaviour
{
    private GameObject middleWall;
    private Color originalColor;

    private void Start()
    {
        middleWall = GameObject.Find("Middle");
        originalColor = middleWall.GetComponent<SpriteRenderer>().color;
    }

    public void CloseMiddle()
    {
        StartCoroutine(Close());
    }

    private IEnumerator Close()
    {
        middleWall.layer = 0;
        middleWall.GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(5f);
        middleWall.layer = 8;
        middleWall.GetComponent<SpriteRenderer>().color = originalColor;
    }
}
