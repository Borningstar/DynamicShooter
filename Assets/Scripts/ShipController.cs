using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipController : MonoBehaviour {

    public float speed;
    public GameObject reactorSocket;
    public GameObject[] weaponSockets;
    public GUIText reactorText;

    private Reactor reactor;
    private Rigidbody rb;
    private List<Weapon> weapons;
    
    void Start ()
    {
        weapons = new List<Weapon>();

        rb = GetComponent<Rigidbody>();
        reactor = reactorSocket.GetComponent<Reactor>();

        foreach(var weaponSocket in weaponSockets)
        {
            weapons.Add(weaponSocket.GetComponent<Weapon>());
        }
    }
	
	void Update ()
    {
        reactorText.text = reactor.CurrentCharge.ToString();

        if (Input.GetButton("Fire1"))
        {
            foreach(var weapon in weapons)
            {
                weapon.Fire(transform, reactor);
            }
        }
	}

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.velocity = movement * speed;
    }
}
