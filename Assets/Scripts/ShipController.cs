using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Enemy;
using Assets.Scripts.Mounts;
using Assets.Scripts.Items.Reactors;
using Assets.Scripts.Items;

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
    public Shield shield;

    private Rigidbody rb;
    
    void Start ()
    {
        this.rb = this.GetComponent<Rigidbody>();

        if (this.reactorMount.Mounted == null)
        {
            this.reactorMount.Mounted = this.baseReactor;
        }

        this.shield.ConnectReactor(reactorMount.Mounted);

        foreach (var mount in this.mountGroup)
        {
            if (mount.Mounted != null)
            {
                mount.Mounted.ConnectReactor(this.reactorMount.Mounted);
            }
        }

        foreach (var mount in this.mountGroupSecondary)
        {
            if (mount.Mounted != null)
            {
                mount.Mounted.ConnectReactor(this.reactorMount.Mounted);
            }
        }
    }
	
	void Update ()
    {
        this.reactorText.text = "Reactor: " + this.reactorMount.Mounted.ToString();
        this.shieldText.text = "Shield: " + this.shield.ToString();
        this.hullText.text = "Hull: " + this.hull.ToString();

        if (Input.GetButton("Fire1"))
        {
            foreach (var mount in this.mountGroup)
            {
                if (mount.Mounted != null)
                {
                    mount.Mounted.Fire();
                }
            }
        }

        if (Input.GetButton("Fire2"))
        {
            foreach (var mount in this.mountGroupSecondary)
            {
                if (mount.Mounted != null)
                {
                    mount.Mounted.Fire();
                }
            }
        }
    }

    public List<IItem> GetItems()
    {
        var items = new List<IItem>();

        if (this.reactorMount != null)
        {
            items.Add(this.reactorMount.Mounted);
        }

        if (this.shield != null)
        {
            //TODO: get shield when refactor done
            //items.Add(this.shield);
        }

        if (this.hull != null)
        {
            //TODO: Get hull when refactor done
            //items.Add(this.hull);
        }

        return items;
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
        var reactor = this.reactorMount.Mounted;

        this.reactorMount = null;

        return reactor;
    }

    private void MountReactor(Reactor reactor)
    {
        this.reactorMount.Mounted = reactor;
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
