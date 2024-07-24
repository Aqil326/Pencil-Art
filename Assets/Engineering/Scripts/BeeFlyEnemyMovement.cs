using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeFlyEnemyMovement : MonoBehaviour
{
  
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float moveSpeed = 5f; // Speed of the movement

    private bool isMoving = false;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        // Initialize positions with integer values
       // startPosition = new Vector3(0, 0, 0); // Example start position
      //  endPosition = new Vector3(10, 0, 0);  // Example end position
        transform.position = startPosition;

        // Calculate the journey length
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    void Update()
    {
        
        if (!isMoving)
        {
            // Calculate the distance covered based on the elapsed time
         //   float distCovered = (Time.time - startTime) * moveSpeed;

            // Calculate the fraction of the journey completed
        //    float fractionOfJourney = distCovered / journeyLength;

            // Move the object towards the end position
            transform.position = Vector3.Lerp(startPosition, endPosition,5f);

            // Stop moving when the destination is reached
            //if (fractionOfJourney >= 1)
            //{
            //    isMoving = false;
            //}
        }
    }

    // Start the movement from start to end position
    public void StartMoving()
    {
        startTime = Time.time;
        isMoving = true;
    }

    // Stop the movement at the current position
    public void StopMoving()
    {
        isMoving = false;
    }
}


