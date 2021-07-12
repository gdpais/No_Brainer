using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsInTime
{
    private Vector2 position;
    private Quaternion rotation;
    private Vector3 localState;

    public PointsInTime(Vector2 position, Quaternion rotation, Vector3 localState)
    {
        this.position = position;
        this.rotation = rotation;
        this.localState = localState;
    }
    public Vector2 GetPos()
    {
        return position;
    }
    public Quaternion GetRotation()
    {
        return rotation;
    }

    public Vector3 GetLocalState()
    {
        return localState;
    }
}
