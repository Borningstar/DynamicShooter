using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speed;
    public float health;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    public bool DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            return false;
        }
        return false;
    }
}
