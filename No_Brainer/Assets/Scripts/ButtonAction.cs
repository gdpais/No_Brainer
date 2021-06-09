using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    //When in contact with a player oe a movableBox starts the pressed button animation
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("boxMovable") || other.gameObject.CompareTag("Player"))
        {
            isPressed = true;
            //Starts pressed animation
            GetComponent<Animator>().SetTrigger("TriggerPressed");
        }
    }

    //When the box or the player leaves the button, this one goes back to its start position
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("boxMovable") || other.gameObject.CompareTag("Player"))
        {
            isPressed = false;
            //Starts relieved animation
            GetComponent<Animator>().SetTrigger("TriggerReleved");
        }
    }

    public bool GetIsPressed()
    {
        return isPressed;
    }
}
