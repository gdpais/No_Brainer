using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    private int score;
    public Text countText;
    float horizontalMove = 0f;
    bool jump = false;
    public GameObject tryAgain;
    public AudioClip pickupSound;
    public AudioClip deathSound;

    private void Start()
    {
        score = 0;
        SetCounterText();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }


    private void FixedUpdate()
    {
        //Handle slopes
        controller.NormalizeSlope();
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    //Increment score, updates the score message and destroy the object that was chatched 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            score += 1;
            SetCounterText();
            Destroy(other.gameObject);
        }

        /*   if (other.gameObject.CompareTag("badguy"))
          {
              DieMoment();
          } */
    }

    //Checks collisions with enemies 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("badguy"))
        {
            DieMoment();
        }
    }


    private void DieMoment()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        gameObject.GetComponent<SpriteRenderer>().flipY = true;
        CapsuleCollider2D coll = gameObject.GetComponent<CapsuleCollider2D>();
        coll.enabled = false;
        StartCoroutine(TimeStop());
    }

    //Stops time after dieing 
    IEnumerator TimeStop()
    {
        // Move the first cube up or down.
        yield return new WaitForSeconds(0.35f);
        Time.timeScale = 0f;
        tryAgain.SetActive(true);
    }

    //Score message
    private void SetCounterText()
    {
        countText.text = score.ToString() + ' ';
    }
    public int GetScore()
    {
        return score;
    }
}
