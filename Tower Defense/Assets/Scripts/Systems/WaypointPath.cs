using System;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform GetWaypoint(int index)
    {
        return waypoints[index];
    }
}