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
        controller.NormalizeSlope();
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            score += 1;
            SetCounterText();
            Destroy(other.gameObject);
        }
    }

    //score message
    private void SetCounterText()
    {
        countText.text = score.ToString() + ' ';
    }
}
