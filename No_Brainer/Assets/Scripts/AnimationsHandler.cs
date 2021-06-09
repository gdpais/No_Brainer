using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    void Start()
    {
        //makes the telekinesis invisible
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the telekinesis animation visible if mouse1 is pressed 
        //Or invisible if it isnt pressed
        if (Input.GetMouseButton(0))
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
