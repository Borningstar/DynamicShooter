using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enemy;

public class ShipController : MonoBehaviour {

    public float speed;

    public GUIText reactorText;
    public GUIText shieldText;
    public GUIText hullText;

    public Reactor reactor;
    public Hull hull;
    public List<Weapon> weaponGroup;
    public List<Weapon> weaponGroupSecondary;
    public Shield shield;

    private Rigidbody rb;

    private const float COLLISION_DAMAGE = 10;
    
    void Start ()
    {
        shield.ConnectReactor(reactor);
        rb = GetComponent<Rigidbody>();

        foreach (var weapon in weaponGroup)
        {
            weapon.ConnectReactor(reactor);
        }

        foreach (var weapon in weaponGroupSecondary)
        {
            weapon.ConnectReactor(reactor);
        }
    }
	
	void Update ()
    {
        reactorText.text = "Reactor: " + reactor.ToString();
        shieldText.text = "Shield: " + shield.ToString();
        hullText.text = "Hull: " + hull.ToString();

        if (Input.GetButton("Fire1"))
        {
            foreach(var weapon in weaponGroup)
            {
                weapon.Fire(transform);
            }
        }

        if (Input.GetButton("Fire2"))
        {
            foreach (var weapon in weaponGroupSecondary)
            {
                weapon.Fire(transform);
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Enemy>().DealDamage(COLLISION_DAMAGE);
            if (shield.CurrentShield > 0)
            {
                shield.DealDamage(shield.CurrentShield);
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

    public void DealDamage(float damage)
    {
        var remaining = shield.DealDamage(damage);

        if (shield.CurrentShield <= 0)
        {
            if (!hull.DealDamage(remaining))
            {
                hullText.text = "Hull: " + hull.ToString();
                Destroy(this.gameObject);
            }
        }
    }
}
