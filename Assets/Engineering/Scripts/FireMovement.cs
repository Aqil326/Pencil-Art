using UnityEngine;

public class FireMovement : MonoBehaviour
{
    private Transform target;
    public float speed = 5f;

    public void SetTarget(Transform target)
    {
        this.target = target;

    }

    void Update()
    {
        if (target != null)
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            // If target is null (player is destroyed), destroy the fire
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // If collided with player, destroy the fire
          //  Destroy(gameObject);

            Debug.Log("Fire Destroied");
        }
    }
}
