using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
* Telekinesis Animation
*/
public class AnimationsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject telekinesis;
    public GameObject waves;
    private bool isActive; //waves power

    private RewindTime rewindTime;
    void Start()
    {
        //makes the telekinesis invisible
        telekinesis.SetActive(false);
        waves.SetActive(false);
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the telekinesis animation visible if mouse1 is pressed 
        //Or invisible if it is not pressed
        if (Input.GetMouseButton(0))
            telekinesis.SetActive(true);
        else
            telekinesis.SetActive(false);


        if (isActive)
        {
            if (Input.GetKey(KeyCode.E))
                waves.SetActive(true);
            else
                waves.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wavesPower"))
        {
            isActive = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("rewindPower"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("increasePower"))
        {
            Destroy(other.gameObject);
        }
    }
}

