using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBall : MonoBehaviour
{
    static public bool isDamageable = false;
    static public int dm = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterController2D.life -= 2;
            Debug.Log(CharacterController2D.life);
            Health.DereaseHealth(0.1f);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
