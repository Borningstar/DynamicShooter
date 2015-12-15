using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enemy;
using Assets.Scripts.Mounts;

public class ShipController : MonoBehaviour {

    private const float COLLISION_DAMAGE = 10;
    private const int WEAPON_GROUP_SIZE = 2;
    private const int WEAPON_GROUP_SECONDARY_SIZE = 1;

    public float speed;

    public GUIText reactorText;
    public GUIText shieldText;
    public GUIText hullText;

    public ReactorMount reactorMount;

    public Reactor baseReactor;
    public Hull hull;

    public WeaponMount[] mountGroup;
    public WeaponMount[] mountGroupSecondary;
    public int weaponGroupSecondarySize;
    public Shield shield;

    private Rigidbody rb;
    
    void Start ()
    {
        this.rb = this.GetComponent<Rigidbody>();

        if (this.reactorMount.mounted == null)
        {
            this.reactorMount.mounted = this.baseReactor;
        }

        this.shield.ConnectReactor(reactorMount.mounted);

        foreach (var mount in this.mountGroup)
        {
            if (mount.mounted != null)
            {
                mount.mounted.ConnectReactor(this.reactorMount.mounted);
            }
        }

        foreach (var mount in this.mountGroupSecondary)
        {
            if (mount.mounted != null)
            {
                mount.mounted.ConnectReactor(this.reactorMount.mounted);
            }
        }
    }
	
	void Update ()
    {
        this.reactorText.text = "Reactor: " + this.reactorMount.mounted.ToString();
        this.shieldText.text = "Shield: " + this.shield.ToString();
        this.hullText.text = "Hull: " + this.hull.ToString();

        if (Input.GetButton("Fire1"))
        {
            foreach (var mount in this.mountGroup)
            {
                if (mount.mounted != null)
                {
                    mount.mounted.Fire();
                }
            }
        }

        if (Input.GetButton("Fire2"))
        {
            foreach (var mount in this.mountGroupSecondary)
            {
                if (mount.mounted != null)
                {
                    mount.mounted.Fire();
                }
            }
        }
    }

    public List<Component> GetComponents()
    {
        var components = new List<Component>();

        if (this.reactorMount != null)
        {
            components.Add(this.reactorMount.mounted);
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

    public List<Mount> GetWeaponMounts()
    {
        var weaponMounts = new List<Mount>();

        weaponMounts.AddRange(this.mountGroup);
        weaponMounts.AddRange(this.mountGroupSecondary);

        return weaponMounts;
    }

    public Reactor DetachReactor()
    {
        var reactor = this.reactorMount.mounted;

        this.reactorMount = null;

        return reactor;
    }

    private void MountReactor(Reactor reactor)
    {
        this.reactorMount.mounted = reactor;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Enemy>().DealDamage(COLLISION_DAMAGE);
            if (this.shield.CurrentShield > 0)
            {
                this.shield.DealDamage(this.shield.CurrentShield);
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

        this.rb.velocity = movement * this.speed;
    }

    public void DealDamage(float damage)
    {
        var remaining = this.shield.DealDamage(damage);

        if (this.shield.CurrentShield <= 0)
        {
            if (!this.hull.DealDamage(remaining))
            {
                this.hullText.text = "Hull: " + this.hull.ToString();
                Destroy(this.gameObject);
            }
        }
    }
}
