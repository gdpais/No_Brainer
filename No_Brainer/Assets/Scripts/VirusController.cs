using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    public float minLimit = 21.0f;
    public float maxLimit = 31.0f;
    private int direction = 1;
    private bool isReturning;

    private void Start()
    {
        isReturning = false;
    }
    // Update is called once per frame
    void Update()
    {



    }
    private void FixedUpdate()
    {
        transform.Translate(direction * Vector2.right * Time.deltaTime);
        if (transform.position.x < minLimit || transform.position.x > maxLimit)
        {
            if (!isReturning)
            {
                direction *= -1;
                isReturning = true;
            }
        }

        if (transform.position.x >= minLimit && transform.position.x <= maxLimit)
        {
            isReturning = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        direction *= -1;
    }
}
