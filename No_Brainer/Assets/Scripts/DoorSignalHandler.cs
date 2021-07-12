using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DoorSignalHandler : MonoBehaviour
{
    private static int NUMBER_OF_BUTTONS = 3;
    public GameObject[] buttonsList = new GameObject[NUMBER_OF_BUTTONS];
    // Start is called before the first frame update
    public GameObject door;
    private bool firstTime;
    [SerializeField] private CinemachineVirtualCamera vCam1; //Main Camera
    [SerializeField] private CinemachineVirtualCamera vCam2; //door camera 

    void Start()
    {
        firstTime = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (checkPressedButton())
        {
            if (firstTime)
            {
                vCam1.Priority = 0;
                vCam2.Priority = 1;
                StartCoroutine(OpenFirst());
                StartCoroutine(WaitForAnim());

            }
            else
            {
                OpenDoor();
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("redToGreen", false);
            door.GetComponent<Animator>().SetBool("Close", false);
        }
    }

    private void OpenDoor()
    {
        GetComponent<Animator>().SetBool("redToGreen", true);
        door.GetComponent<Animator>().SetBool("Close", true);
    }

    /**
    * Opens doors for the first time every game
    * Waits for the camera movement
    */
    IEnumerator OpenFirst()
    {
        // Move the first cube up or down.
        yield return new WaitForSeconds(1.6f);
        OpenDoor();
        firstTime = false;

    }


    IEnumerator WaitForAnim()
    {
        // Move the first cube up or down.
        yield return new WaitForSeconds(3.0f);
        vCam1.Priority = 1;
        vCam2.Priority = 0;
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
