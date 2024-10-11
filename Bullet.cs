using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
  

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null) 
        {
            enemy.TakeDamage(damage); 
        }
        Destroy(gameObject); 
    }
}
