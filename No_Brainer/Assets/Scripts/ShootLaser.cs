using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    public int toLeft = -1; //left =-1 right =1
    LaserBeam beam;
    void Start()
    {
        beam = new LaserBeam(gameObject.transform.position, (toLeft * gameObject.transform.right), material);
    }



    // Update is called once per frame
    void Update()
    {
        beam.DestroyLaser();
        beam.SetProperties(gameObject.transform.position, -gameObject.transform.right);
    }
}
