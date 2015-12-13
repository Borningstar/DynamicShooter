using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enemy;

public class ShipController : MonoBehaviour {

    private const float COLLISION_DAMAGE = 10;
    private const int WEAPON_GROUP_SIZE = 2;
    private const int WEAPON_GROUP_SECONDARY_SIZE = 1;

    public float speed;

    public GUIText reactorText;
    public GUIText shieldText;
    public GUIText hullText;

    public Reactor reactor;
    public Reactor baseReactor;
    public Hull hull;
    //public Weapon[] weaponGroup = new Weapon[WEAPON_GROUP_SIZE];
    //public Weapon[] weaponGroupSecondary = new Weapon[WEAPON_GROUP_SECONDARY_SIZE];

    public WeaponMount[] mountGroup;
    public WeaponMount[] mountGroupSecondary;
    public int weaponGroupSecondarySize;
    public Shield shield;

    private Rigidbody rb;
    
    void Start ()
    {
        shield.ConnectReactor(reactor);
        rb = GetComponent<Rigidbody>();

        reactor = null;

        if (reactor == null)
        {
            reactor = baseReactor;
        }

        foreach (var mount in mountGroup)
        {
            if (mount.weapon != null)
            {
                mount.weapon.ConnectReactor(reactor);
            }
        }

        foreach (var mount in mountGroupSecondary)
        {
            if (mount.weapon != null)
            {
                mount.weapon.ConnectReactor(reactor);
            }
        }
    }
	
	void Update ()
    {
        reactorText.text = "Reactor: " + reactor.ToString();
        shieldText.text = "Shield: " + shield.ToString();
        hullText.text = "Hull: " + hull.ToString();

        if (Input.GetButton("Fire1"))
        {
            foreach (var mount in mountGroup)
            {
                if (mount.weapon != null)
                {
                    mount.weapon.Fire();
                }
            }
        }

        if (Input.GetButton("Fire2"))
        {
            foreach (var mount in mountGroupSecondary)
            {
                if (mount.weapon != null)
                {
                    mount.weapon.Fire();
                }
            }
        }
    }

    public List<Component> GetComponents()
    {
        var components = new List<Component>();

        if (this.reactor != null)
        {
            components.Add(this.reactor);
        }

        if (this.shield != null)
        {
            components.Add(this.shield);
        }

        if (this.hull != null)
        {
            components.Add(this.hull);
        }

        return components;
    }

    public List<WeaponMount> GetWeaponMounts()
    {
        var weaponMounts = new List<WeaponMount>();

        weaponMounts.AddRange(mountGroup);
        weaponMounts.AddRange(mountGroupSecondary);

        return weaponMounts;
    }

    public Reactor DetachReactor()
    {
        var thisReactor = reactor;

        reactor = null;

        return thisReactor;
    }

    private void MountReactor(Reactor reactor)
    {

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
