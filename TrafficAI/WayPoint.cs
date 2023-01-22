using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Header("Way point Status")]
    public WayPoint previousWayPoint;
    public WayPoint nextWayPoint;

    [Range(0f, 5f)]
    public float wayPointWidth = 1f;
    public List<WayPoint> branches = new List<WayPoint>();

    [Range(0f, 1f)]
    public float branchRatio = 0.5f;
    

    public Vector3 GetPosition() {
        Vector3 minBound = transform.position + transform.right * wayPointWidth / 2f;
        Vector3 maxBound = transform.position - transform.right * wayPointWidth / 2f;
        return Vector3.Lerp(minBound, maxBound, Random.Range(0f, 1f));
    }
}
