using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassDetection : MonoBehaviour
{
    public static bool isPlayeringrass = false;

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Grass"))
        {
            isPlayeringrass = true;
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grass"))
        {
            isPlayeringrass = false;
           
        }
    }

}
