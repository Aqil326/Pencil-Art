using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSight : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1.0f;

    [SerializeField] private GameObject imageObject;

    [SerializeField] private float rotationLimit = 90.0f;

    private float currentRotation = 0f;

    private void Update()
    {
        if (imageObject != null)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;

            currentRotation += rotationThisFrame;

            if (Mathf.Abs(currentRotation) > rotationLimit)
            {
                rotationThisFrame -= (Mathf.Abs(currentRotation) - rotationLimit) * Mathf.Sign(rotationThisFrame);
                currentRotation = rotationLimit * Mathf.Sign(currentRotation);
            }

            imageObject.transform.Rotate(Vector3.forward * rotationThisFrame);

            if (Mathf.Abs(currentRotation) >= rotationLimit)
            {
                rotationSpeed *= -1;
            }
        }
    }
}