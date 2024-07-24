using Unity.VisualScripting;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Define the layer numbers
        int playerLayer = LayerMask.NameToLayer("Player");
        int platformsLayer = LayerMask.NameToLayer("Platforms");

        // Check if the collision object's layer matches either the player or platforms layer
        if (collision.gameObject.layer == playerLayer || collision.gameObject.layer == platformsLayer)
        {
            Destroy(gameObject);
        }
    }
}
