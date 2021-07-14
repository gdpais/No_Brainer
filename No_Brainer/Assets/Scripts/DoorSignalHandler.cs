using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DoorSignalHandler : MonoBehaviour
{
    private static int NUMBER_OF_BUTTONS = 3;
    public GameObject[] buttonsList = new GameObject[NUMBER_OF_BUTTONS];
    public GameObject door;
    private bool firstTime;
    [SerializeField] private CinemachineVirtualCamera vCam1; //Main Camera
    [SerializeField] private CinemachineVirtualCamera vCam2; //door camera 
    public bool forceOpen = true;
    public int NUMB_OF_NEURONS = 11;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        firstTime = true;
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
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


        if (!forceOpen && player != null)
        {
            if (player.GetScore() < NUMB_OF_NEURONS)
            {
                canOpen = false;
            }
            else
            {
            }
        }
        return canOpen;
    }
}
