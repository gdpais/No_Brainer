using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;
    private int score;
    public Text countText;
    float horizontalMove = 0f;
    bool jump = false;

    private void Start()
    {
        score = 0;
        SetCounterText();
    }

    // Update is called once per frame
    private void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

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
            score += 1;
            SetCounterText();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("badguy"))
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
            CapsuleCollider2D coll = gameObject.GetComponent<CapsuleCollider2D>();
            coll.enabled = false;
            StartCoroutine(Example());
        }
    }

    IEnumerator Example()
    {
        // Move the first cube up or down.
        yield return new WaitForSeconds(0.35f);
        Time.timeScale = 0f;
    }

    //Score message
    private void SetCounterText()
    {
        countText.text = score.ToString() + ' ';
    }
}
