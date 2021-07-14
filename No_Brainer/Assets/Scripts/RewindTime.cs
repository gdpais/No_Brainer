using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTime : MonoBehaviour
{
    private Rigidbody2D rb;
    private List<PointsInTime> recordedPoints;
    private bool isRewinding = false;

    //Echo Effect
    public GameObject echo;
    private float timeBtwSpawns;
    private float startTimeBtwSpawns = 0.05f;

    public GameObject rewindPower;

    // Start is called before the first frame update
    void Start()
    {
        recordedPoints = new List<PointsInTime>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) StartRewind();
        if (Input.GetKeyUp(KeyCode.R)) StopRewind();
    }

    private void FixedUpdate()
    {
        //If the gameObject is on screen
        Vector2 pointOnScreen = Camera.main.WorldToScreenPoint(GetComponentInChildren<Renderer>().bounds.center);
        if ((pointOnScreen.x > 0) && (pointOnScreen.x < Screen.width) &&
                        (pointOnScreen.y > 0) && (pointOnScreen.y < Screen.height) && this != null && rewindPower == null)
        {
            if (isRewinding) Rewind(); else RecordPos();
        }
    }

    //Rewinds time
    private void Rewind()
    {
        if (recordedPoints.Count > 0)
        {
            Fade();
            PointsInTime somePoint = recordedPoints[0];
            transform.position = somePoint.GetPos();
            transform.rotation = somePoint.GetRotation();
            transform.localScale = somePoint.GetLocalState();
            recordedPoints.RemoveAt(0);
        }
        else { StopRewind(); }
    }

    //Saves the gameObject position
    private void RecordPos()
    {
        if (recordedPoints.Count > Mathf.Round(3.0f / Time.fixedDeltaTime))
            recordedPoints.RemoveAt(recordedPoints.Count - 1);
        recordedPoints.Insert(0, new PointsInTime(transform.position, transform.rotation, transform.localScale));
    }


    private void StartRewind()
    {
        isRewinding = true;
    }
    private void StopRewind()
    {
        isRewinding = false;
    }

    //Handles gameObject echo effect 
    public void Fade()
    {
        if (rb.velocity.magnitude != 0)
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, transform.rotation);
                Destroy(instance, 8f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
