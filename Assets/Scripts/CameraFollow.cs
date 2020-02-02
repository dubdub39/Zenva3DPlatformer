using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    private void Update()
    {
        //if we don't have a target object assigned, exit out of this method
        if (target == null)
            return;
        //code to track our player.  a vector3 is assigned to have the same coordinates as our
        //player, plus an offset amount to create distance between player & camera.
        //offset.y just keeps the Y axis in a set position assigned by us in the inspector.  We do this in
        //case we don't want the camera to slightly track upwards with our player whenever he jumps.

        Vector3 newPos = target.position + offset;
        //newPos.y = offset.y;

        transform.position = newPos;
    }

}
