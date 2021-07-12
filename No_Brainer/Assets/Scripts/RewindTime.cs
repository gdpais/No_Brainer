using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTime : MonoBehaviour
{
    private Rigidbody2D rb;
    private List<PointsInTime> recordedPoints;
    private bool isRewinding = false;
    private bool canRewind = true;
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
                        (pointOnScreen.y > 0) && (pointOnScreen.y < Screen.height) && this != null)
        {
            if (isRewinding) Rewind(); else RecordPos();
        }
    }

    private void Rewind()
    {
        if (recordedPoints.Count > 0)
        {
            PointsInTime somePoint = recordedPoints[0];
            transform.position = somePoint.GetPos();
            transform.rotation = somePoint.GetRotation();
            recordedPoints.RemoveAt(0);
        }
        else { StopRewind(); }
    }

    private void RecordPos()
    {
        if (recordedPoints.Count > Mathf.Round(6.0f / Time.fixedDeltaTime))
            recordedPoints.RemoveAt(recordedPoints.Count - 1);
        recordedPoints.Insert(0, new PointsInTime(transform.position, transform.rotation));
    }

    private void StartRewind()
    {
        isRewinding = true;
    }
    private void StopRewind()
    {
        isRewinding = false;
    }
}
