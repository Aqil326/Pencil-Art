using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 1.0f;
    private bool movingTowardsB = true;

    private void Update()
    {
        if (movingTowardsB && !Detector.Captured)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);
            if (transform.position == pointB)
            {
                movingTowardsB = false;
                RotateObject();
            }
        }
        else if(!Detector.Captured)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);
            if (transform.position == pointA)
            {
                movingTowardsB = true;
                RotateObject();
            }
        }
    }

    private void RotateObject()
    {
        // Rotate 180 degrees around the Y axis
        transform.Rotate(0, 180, 0);
    }
}
