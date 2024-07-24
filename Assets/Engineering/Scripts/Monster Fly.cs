using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFly : MonoBehaviour
{
    public GameObject fireballPrefab; // Reference to the fireball prefab to be instantiated
    public Transform fireballSpawnPoint; // The point from which the fireball will be spawned (launched)
    public GameObject player; // Reference to the player GameObject to aim the projectile at
    public float projectileSpeed = 5f; // Speed at which the fireball moves towards the player

    //public bool captured = false; // Uncomment and use this if you want a condition within this script to control shooting

    private float attackRate = 2f; // Frequency of attacks in seconds (how often the monster shoots)
    private float nextAttackTime = 0f; // When the next attack should happen (time in seconds)

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // Check if the current time has passed the nextAttackTime and if the 'captured' condition (external condition) is true
        if (Time.time >= nextAttackTime && Detector.Captured)
        {
            LaunchProjectile(); // Call the method to launch a fireball
            nextAttackTime = Time.time + attackRate; // Calculate the time for the next attack based on the current time and attackRate
        }
    }

    void LaunchProjectile()
    {
        if (fireballPrefab != null && player != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (player.transform.position - fireball.transform.position).normalized;
                rb.velocity = direction * projectileSpeed;
            }
            else
            {
                Rigidbody rb3D = fireball.GetComponent<Rigidbody>();
                if (rb3D != null)
                {
                    Vector3 direction = (player.transform.position - fireball.transform.position).normalized;
                    rb3D.velocity = direction * projectileSpeed;
                }
            }
        }
    }
}
