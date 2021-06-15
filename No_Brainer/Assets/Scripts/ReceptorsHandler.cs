using UnityEngine;

public class ReceptorsHandler : MonoBehaviour
{
    private static int NUMBER_OF_RECEPTORS = 2;
    public GameObject[] receptorsList = new GameObject[NUMBER_OF_RECEPTORS];
    public GameObject door;
    private bool canOpen;
    void Start()
    {
        canOpen = false;
    }
    // Update is called once per frame
    void Update()
    {
        CanOpen();
        if (canOpen)
        {
            GetComponent<Animator>().SetBool("redToGreen", true);
            door.GetComponent<Animator>().SetBool("Close", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("redToGreen", false);
            door.GetComponent<Animator>().SetBool("Close", false);
        }
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
