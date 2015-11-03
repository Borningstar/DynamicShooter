using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float Cost;
    public float speed;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
	
	void Update ()
    {
	
	}
}
