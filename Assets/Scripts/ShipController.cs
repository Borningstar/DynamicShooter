using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipController : MonoBehaviour {

    public float speed;

    public GameObject reactorSocket;
    public GameObject[] weaponSockets;
    public GameObject shieldSocket;
    public GameObject hullSocket;

    public GUIText reactorText;
    public GUIText shieldText;
    public GUIText hullText;

    private Rigidbody rb;

    private Reactor reactor;
    private Hull hull;
    private List<Weapon> weapons;
    private Shield shield;
    private const float COLLISION_DAMAGE = 10;
    
    void Start ()
    {
        reactor = reactorSocket.GetComponent<Reactor>();
        hull = hullSocket.GetComponent<Hull>();
        weapons = new List<Weapon>();
        shield = shieldSocket.GetComponent<Shield>();
        shield.ConnectReactor(reactor);
        rb = GetComponent<Rigidbody>();

        foreach(var weaponSocket in weaponSockets)
        {
            weapons.Add(weaponSocket.GetComponent<Weapon>());
        }

        foreach (var weapon in weapons)
        {
            weapon.ConnectReactor(reactor);
        }
    }
	
	void Update ()
    {
        reactorText.text = reactor.ToString();
        shieldText.text = shield.ToString();
        hullText.text = hull.ToString();

        if (Input.GetButton("Fire1"))
        {
            foreach(var weapon in weapons)
            {
                weapon.Fire(transform);
            }
        }
	}

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Enemy>().TakeDamage(COLLISION_DAMAGE);
            if (shield.CurrentShield > 0)
            {
                shield.TakeDamage(shield.CurrentShield);
            }
            else
            {
                Destroy(this.gameObject);
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

    public void TakeDamage(float damage)
    {
        var remaining = shield.TakeDamage(damage);

        if (shield.CurrentShield < 0)
        {
            if (!hull.DealDamage(remaining))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
