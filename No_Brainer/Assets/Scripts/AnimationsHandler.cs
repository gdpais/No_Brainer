using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Telekinesis Animation
*/
public class AnimationsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject telekinesis;
    public GameObject waves;
    void Start()
    {
        //makes the telekinesis invisible
        telekinesis.SetActive(false);
        waves.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the telekinesis animation visible if mouse1 is pressed 
        //Or invisible if it is not pressed
        if (Input.GetMouseButton(0))
        {
            telekinesis.SetActive(true);
        }
        else
        {
            telekinesis.SetActive(false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            waves.SetActive(true);
        }
        else
        {
            waves.SetActive(false);
        }
    }
}

