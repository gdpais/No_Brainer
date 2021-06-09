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

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("boxMovable") || other.gameObject.CompareTag("player"))
        {
            isPressed = true;
            GetComponent<Animator>().SetTrigger("TriggerPressed");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("boxMovable") || other.gameObject.CompareTag("player"))
        {
            isPressed = false;
            GetComponent<Animator>().SetTrigger("TriggerReleved");
        }
    }
}
