using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float timer = 0;
        timer += Time.deltaTime;
        if (timer % 5 == 0)
            transform.Translate(Vector2.right * Time.deltaTime);
        else
            transform.Translate(Vector2.right * -Time.deltaTime);
    }



}
