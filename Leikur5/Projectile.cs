using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    
    void Update()
    {
        // Hraði tannhjóls
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    
    
    // Í þessu verkefni gerir þessi kóði að neðan ekkert, en hann er en í notkun í fyrirverandi verkfni
    void OnCollisionEnter2D(Collision2D other)
    {
        // Segir vélmenninu til að lagast ef tannhjólið rekst á það
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
            e.transform.tag = "Fixed";
        }
    
        Destroy(gameObject);
    }
}
