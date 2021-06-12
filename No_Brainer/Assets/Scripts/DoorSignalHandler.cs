using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSignalHandler : MonoBehaviour
{
    private static int NUMBER_OF_BUTTONS = 3;
    public GameObject[] buttonsList = new GameObject[NUMBER_OF_BUTTONS];
    // Start is called before the first frame update
    private bool arePressed;
    public GameObject door;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (checkPressedButton())
        {
            GetComponent<Animator>().SetTrigger("redToGreen");
            door.GetComponent<Animator>().SetTrigger("Open");

        }
        else
        {
            GetComponent<Animator>().SetTrigger("greenToRed");
            door.GetComponent<Animator>().SetTrigger("Close");
        }

    }

    //Checks if all needed buttons are pressed
    private bool checkPressedButton()
    {
        for (int i = 0; i < buttonsList.Length; i++)
        {
            if (!buttonsList[i].GetComponent<ButtonAction>().GetIsPressed())
            {
                //Debug.Log("Pressed");
                //GetComponent<Animator>().SetTrigger("redToGreen");
                //arePressed = true;
                return false;
            }
            /* if (arePressed && !buttonsList[i].GetComponent<ButtonAction>().GetIsPressed())
             {
                 //Debug.Log("Relieved");
                 //GetComponent<Animator>().SetTrigger("greenToRed");
                 arePressed = false;
                 break;
             }*/
        }
        return true;
    }
}
