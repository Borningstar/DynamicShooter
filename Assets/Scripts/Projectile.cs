﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float cost;
    public float speed;
    public float damage;

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