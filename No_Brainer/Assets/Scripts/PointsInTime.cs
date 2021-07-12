using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsInTime
{
    private Vector2 position;
    private Quaternion rotation;

    public PointsInTime(Vector2 position, Quaternion rotation)
    {
        this.position = position;
        this.rotation = rotation;
    }
    public Vector2 GetPos()
    {
        return position;
    }
    public Quaternion GetRotation()
    {
        return rotation;
    }
}
