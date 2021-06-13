using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{

    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float timer = 0;
        timer += Time.deltaTime;
        if ((timer % 5) == 0)
            transform.Translate(direction * Vector2.right * Time.deltaTime);
        else
            transform.Translate(direction * Vector2.right * Time.deltaTime);
    }

    private void OnParticleCollision(GameObject other)
    {
        direction *= -1;
    }

}
