using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    void Start()
    {
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
