using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    ////////-------------ADJUST---------------------
    public Transform target;
    //public float c_distance = 100.0f;
    public float smoothTime = 0.3F;

    public float xUpperLim = 19.2f;
    public float xLowerLim = 8.5f;
    public float yUpperLim = 8.7f;
    public float yLowerLim = 5.2f;

    Vector3 curr_pos, dest, offset, distance;
    Vector3 vel = Vector3.zero;
    
    
    void Start()
    {
        //initialize position variables
        target = transform.parent;
        transform.parent = null;
        transform.position = target.position;


        offset = new Vector3(0, 0, -30);
    }

    void LateUpdate()
    {
        //find target position
        offset = new Vector3(   Mathf.Clamp(target.position.x, xLowerLim, xUpperLim),
                                Mathf.Clamp(target.position.y, yLowerLim, yUpperLim), -30);

        //smoothly move the camera towards player
        transform.position = Vector3.SmoothDamp(transform.position, offset, ref vel, smoothTime);
    }
}
