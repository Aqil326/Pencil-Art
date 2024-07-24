using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    public Transform player; // Assign the player's transform in the inspector
    public float detectionRadius = 5.0f; // The detection radius

    public static bool playerDetected = false; // To track the detection state
    public GameObject Eye;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DetectPlayer();
    }

    void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            if (!playerDetected)
            {
                playerDetected = true;
                // Additional code to make the monster chase the player
            }
        }
        else
        {
            if (playerDetected)
            {
                Eye.SetActive(true);
                playerDetected = false;
                Detector.Captured = false;
                // Additional code to make the monster stop chasing the player
            }
        }
    }
}

