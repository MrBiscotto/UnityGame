using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int _health = 100;
    protected float hitPerSec = 0.8f;
    protected float lastTimeHit = 0;

    /// <summary>
    /// Dammage receive when bullet hit player
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        { 
            ReceiveDamage(10);
            CheckGameOver();
        }
        if(other.gameObject.tag == "BulletBrainly")
        {
            ReceiveDamage(40);
            CheckGameOver();
        }
    }

    /// <summary>
    /// Get damage if stay in fire with Brainly
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    { 
        if (other.gameObject.tag == "FireBrainly")
            {
                if (Time.time > lastTimeHit + (1 / hitPerSec))
                {
                    ReceiveDamage(10);
                    CheckGameOver();
                    lastTimeHit = Time.time;
                }
            }
    }


    /// <summary>
    /// Damage receive when wheely enter in collision
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wheely")
        {
            ReceiveDamage(5);
            CheckGameOver();
        }
    }

    /// <summary>
    /// Damage receive if wheely stay on player
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wheely")
        {
            if (Time.time > lastTimeHit + (1 / hitPerSec))
            {
                ReceiveDamage(5);
                CheckGameOver();
                lastTimeHit = Time.time;
            }      
        }
    }

    /// <summary>
    /// Damage receive 
    /// </summary>
    /// <param name="damageReceive"></param>
    void ReceiveDamage(int damageReceive)
    {
        _health -= damageReceive;
    }

    /// <summary>
    /// Check if dead 
    /// </summary>
    /// <param name="other"></param>
    /// <param name="tag"></param>
    /// <param name="damageReceive"></param>
    void CheckGameOver()
    {
         if (_health <= 0) Destroy(gameObject);  
    }
}
