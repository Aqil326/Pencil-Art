using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public static bool Captured = false;
    private bool isTriggeringGrass = false;
    private bool isTriggeringEyeSight = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grass"))
        {
            isTriggeringGrass = true;
        }
        else if (other.CompareTag("Eye Sight"))
        {
            isTriggeringEyeSight = true;
            CheckConditionsAndDestroyEyeSight(other.gameObject);
        }
    }
    ///
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Grass"))
        {
            isTriggeringGrass = false;
        }
        else if (other.CompareTag("Eye Sight"))
        {
            isTriggeringEyeSight = false;
        }
    }

    private void CheckConditionsAndDestroyEyeSight(GameObject eyeSightObject)
    {
        if (isTriggeringEyeSight && !isTriggeringGrass)
        {
            Captured = true;
            eyeSightObject.SetActive(false);
        }
    }
}
