using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    public int toLeft = -1; //left =-1 right =1
    LaserBeam beam;
    public GameObject receptor;
    void Start()
    {
        beam = new LaserBeam(gameObject.transform.position, (toLeft * gameObject.transform.right), material, receptor);
    }


    // Update is called once per frame
    void Update()
    {
        beam.DestroyLaser();
        beam.SetProperties(gameObject.transform.position, (toLeft * gameObject.transform.right));
    }
}
