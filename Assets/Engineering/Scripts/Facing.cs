using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    public Transform playerTransform; // Assign this in the inspector with your player's transform

    private Vector3 lastPlayerPosition;
    private float facingDirection = 1f; // 1 for right, -1 for left
    public GameObject Monster;
    void Start()
    {
        // Initialize lastPlayerPosition with the player's initial position
        if (playerTransform != null)
        {
            lastPlayerPosition = playerTransform.position;
        }
    }

    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // Check if the player has moved
        if (playerTransform != null && lastPlayerPosition != playerTransform.position && Detector.Captured)
        {
            RotateTowardsPlayer();
            lastPlayerPosition = playerTransform.position; // Update the last known position
        }
    }

    void RotateTowardsPlayer()
    {
        if (playerTransform.position.x < transform.position.x && facingDirection != 1f && Detector.Captured)
        {
            // Player is to the right of the monster, and monster is not already facing right
            facingDirection = 1f;
            RotateMonster();
        }
        else if (playerTransform.position.x > transform.position.x && facingDirection != -1f && Detector.Captured)
        {
            // Player is to the left of the monster, and monster is not already facing left
            facingDirection = -1f;
            RotateMonster();
        }
    }

    void RotateMonster()
    {
        // This flips the monster's orientation by rotating around the Y axis
        transform.localScale = new Vector3(facingDirection * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
