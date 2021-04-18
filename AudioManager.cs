using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip victoryClip;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            foreach (AudioSource source in FindObjectsOfType<AudioSource>())
            {
                source.mute = !source.mute;
            }
        }
    }

    public void Play(AudioClip clip, float volume, float destroyTime)
    {
        GameObject createdObject = new GameObject();
        createdObject.AddComponent<AudioSource>().clip = clip;
        AudioSource createdSource = createdObject.GetComponent<AudioSource>();

        createdSource.volume = volume;

        createdObject.GetComponent<AudioSource>().Play();
        StartCoroutine(DestroyClip(createdObject, destroyTime));
    }

    private IEnumerator DestroyClip(GameObject clip, float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(clip);
    }

    public IEnumerator VictoryTimer()
    {
        yield return new WaitForSeconds(0.5f);
        Play(victoryClip, 1f, 1f);

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
}
