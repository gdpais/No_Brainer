using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    public float minLimit = 21.0f;
    public float maxLimit = 31.0f;
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Vector2.right * Time.deltaTime);
        if (transform.position.x <= minLimit || transform.position.x >= maxLimit)
            direction *= -1;
    }
}
