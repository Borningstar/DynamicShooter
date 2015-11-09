using UnityEngine;
using System.Collections;
using Assets.Scripts.Enemy;

public class Ammo : MonoBehaviour {

    public float cost;
    public float speed;
    public float damage;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
