using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSignalHandler : MonoBehaviour
{
    private static int NUMBER_OF_BUTTONS = 3;
    public GameObject[] buttonsList = new GameObject[NUMBER_OF_BUTTONS];
    // Start is called before the first frame update
    private bool[] arePressed = { false, false, false };
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
        bool canOpen = true;
        foreach (GameObject button in buttonsList)
        {
            if (!button.GetComponent<ButtonAction>().GetIsPressed())
                canOpen = false;
        }
        return canOpen;
    }
}
