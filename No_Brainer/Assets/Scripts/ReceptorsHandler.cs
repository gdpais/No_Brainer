using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ReceptorsHandler : MonoBehaviour
{
    private static int NUMBER_OF_RECEPTORS = 2;
    public GameObject[] receptorsList = new GameObject[NUMBER_OF_RECEPTORS];
    public GameObject door;
    private bool canOpen;
    private bool firstTime;
    [SerializeField] private CinemachineVirtualCamera vCam1; //Main Camera
    [SerializeField] private CinemachineVirtualCamera vCam2; //door camera 

    void Start()
    {
        canOpen = false;
        firstTime = true;
    }
    // Update is called once per frame
    void Update()
    {
        CanOpen();
        if (canOpen)
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

    /**
    * Opens doors for the first time every game
    * Waits for the camera movement
    */
    IEnumerator OpenFirst()
    {
        // Move the first cube up or down.
        yield return new WaitForSeconds(2.1f);
        OpenDoor();
        firstTime = false;
    }

    IEnumerator WaitForAnim()
    {
        // Move the first cube up or down.
        yield return new WaitForSeconds(4.0f);
        vCam1.Priority = 1;
        vCam2.Priority = 0;
    }

    public void OpenDoor()
    {
        GetComponent<Animator>().SetBool("redToGreen", true);
        door.GetComponent<Animator>().SetBool("Close", true);
    }
    private void CanOpen()
    {
        canOpen = true;
        foreach (GameObject receptor in receptorsList)
        {
            if (!receptor.GetComponent<Animator>().GetBool("isOn"))
                canOpen = false;
        }

    }
}
