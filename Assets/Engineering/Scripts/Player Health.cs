using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Transform tf;
    public static bool Death;
    void Start()
    {
        tf = GetComponent<Transform>();
    }



    public static void IncreaseHealth(float value)
    {
        if (tf.localScale.x < 1)
            tf.localScale += new Vector3(value, 0, 0);
    }

    public static void DereaseHealth(float value)
    {
        if (tf.localScale.x > 0.05f)
            tf.localScale -= new Vector3(value, 0, 0);
    }

}
