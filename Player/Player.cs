using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private bool startedMoving;
    private Vector3 originalPosition;

    public string playerNumber;
    public float fireCooldown;
    private bool canFire = true;
    public int otherScore;

    public Powerup currentPowerup;

    [Header("References")]
    public Animator animator;
    public GameObject bullet;
    public Slider slider;
    public Text otherPlayerScore;
    public Image powerupImage;
    public Sprite emptyPowerupImage;
    public GameObject controls;
    public GameObject muteButton;

    public AudioManager audioManager;
    public AudioClip usePowerupClip;
    public AudioClip shootClip;
    public AudioClip deathClip;

    private void Start()
    {
        transform.right = new Vector3(0f, 0f) - transform.position;

        slider.maxValue = fireCooldown;
        slider.value = fireCooldown;

        originalPosition = transform.position;
        otherScore = 0;

        powerupImage.sprite = emptyPowerupImage;
    }

    void Update()
    {
        if (!startedMoving)
        {
            CheckIfMoved();
        }
        else
        {
            transform.right = Vector2.Lerp(transform.right, 
                                   new Vector3(Input.GetAxisRaw("Horizontal" + playerNumber), Input.GetAxisRaw("Vertical" + playerNumber)),
                                   10 * Time.deltaTime);

            animator.SetFloat("CurrentSpeed", transform.right.sqrMagnitude);

            if (Input.GetAxisRaw("Horizontal" + playerNumber) != 0 || Input.GetAxisRaw("Vertical" + playerNumber) != 0)
                transform.position += transform.right * speed * Time.deltaTime;
            else
            {
                animator.SetFloat("CurrentSpeed", 0f);
            }

            // Firing
            if (canFire)
            {
                if (playerNumber == "1")
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Fire();
                    }
                }
                if (playerNumber == "2")
                {
                    if (Input.GetKeyDown(KeyCode.Slash))
                    {
                        Fire();
                    }
                }
            }

            slider.value += Time.deltaTime;
        }
    }
    
    public bool CheckIfMoved()
    {
        if (Input.GetAxisRaw("Horizontal" + playerNumber) != 0 || Input.GetAxisRaw("Vertical" + playerNumber) != 0)
        {
            if (!startedMoving)
            {
                startedMoving = true;
                transform.right = new Vector3(Input.GetAxisRaw("Horizontal" + playerNumber), Input.GetAxisRaw("Vertical" + playerNumber));
                controls.SetActive(false);
                muteButton.SetActive(false);
            }

            return true;
        }

        return false;
    }

    public void Fire()
    {
        if (currentPowerup != null)
        {
            currentPowerup.UsePowerup.Invoke();
            currentPowerup = null;
            StartCoroutine(Reload());

            powerupImage.sprite = emptyPowerupImage;
            Destroy(currentPowerup);

            audioManager.Play(usePowerupClip, 0.5f, 1f);
            return;
        }

        audioManager.Play(shootClip, 0.5f, 1f);
        Instantiate(bullet, transform.position + transform.right, transform.rotation);
        StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        slider.value = 0f;
        canFire = false;
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }

    public void Die()
    {
        transform.position = originalPosition;
        transform.right = new Vector3(0f, 0f) - transform.position;
        otherScore += 1;
        otherPlayerScore.text = otherScore.ToString();
        audioManager.Play(deathClip, 1f, 1f);

        animator.SetTrigger("Respawn");
        StartCoroutine(Respawn());

        if (otherScore >= 15)
        {
            audioManager.StartCoroutine("VictoryTimer");
            audioManager.GetComponent<AudioSource>().Stop();

            Destroy(gameObject);
        }
    }



    public IEnumerator Respawn()
    {
        gameObject.layer = 8;
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(1f);
        gameObject.layer = 0;
        gameObject.tag = "Player";
    }

    public void ChangePowerup(Powerup newPowerup)
    {
        currentPowerup = newPowerup;

        powerupImage.sprite = newPowerup.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            canFire = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (slider.value == slider.maxValue)
                canFire = true;
        }
    }
}
