using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    Vector2 pos, dir;
    GameObject laserObj;
    LineRenderer laser;
    List<Vector2> laserIndices = new List<Vector2>();

    public LaserBeam(Vector2 pos, Vector2 dir, Material material)
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.blue;
        this.laser.endColor = Color.blue;

    }

    public void SetProperties(Vector2 pos, Vector2 dir)
    {
        CastRay(pos, dir, laser);
    }

    void CastRay(Vector2 pos, Vector2 dir, LineRenderer laser, int max = 1000)
    {
        
        if (max <= 0)
        {
            return;
        }

        laserIndices.Add(pos);
        Ray2D ray = new Ray2D(pos, dir);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 30, 1);
        if (hit)
        {
            CheckHit(hit, dir, laser, max);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(60));
            UpdateLaser();
        }
    }

    public void DestroyLaser()
    {
        laserIndices.Clear();
    }

    void UpdateLaser()
    {

        int count = 0;
        laser.positionCount = laserIndices.Count;
        foreach (Vector2 idx in laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }

    void CheckHit(RaycastHit2D hitInfo, Vector2 direction, LineRenderer laser, int max)
    {
        if (hitInfo.collider.gameObject.tag == "mirror")
        {
            Vector2 pos = hitInfo.point;
            Vector2 dir = Vector2.Reflect(direction, hitInfo.normal);
            CastRay(pos, dir, laser, max - 1);
        }
        else
        {

            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
    }
}
