using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Mounts;
using Assets.Scripts.Items.Reactors;
using Assets.Scripts.Items;
using Assets.Scripts.Items.Shields;
using Assets.Scripts.Items.Hulls;
using Assets.Scripts.Enemy.Ships;

public class ShipController : MonoBehaviour {

    private const float COLLISION_DAMAGE = 10;
    private const int WEAPON_GROUP_SIZE = 2;
    private const int WEAPON_GROUP_SECONDARY_SIZE = 1;

    public float speed;

    public GUIText reactorText;
    public GUIText shieldText;
    public GUIText hullText;

    public Hull hull;

    public ReactorMount reactorMount;
    public ReactorMount baseReactorMount;
    public WeaponMount[] mountGroup;
    public WeaponMount[] mountGroupSecondary;
    public ShieldMount shieldMount;

    private Rigidbody rb;
    
    void Start ()
    {
        this.rb = this.GetComponent<Rigidbody>();

        if (this.reactorMount.Mounted == null)
        {
            this.reactorMount.Mounted = this.baseReactorMount.Mounted;
        }

        this.shieldMount.Mounted.ConnectReactor(reactorMount.Mounted);

        foreach (var weaponMount in this.mountGroup)
        {
            if (weaponMount.Mounted != null)
            {
                weaponMount.Mounted.ConnectReactor(this.reactorMount.Mounted);
            }
        }

        foreach (var weaponMount in this.mountGroupSecondary)
        {
            if (weaponMount.Mounted != null)
            {
                weaponMount.Mounted.ConnectReactor(this.reactorMount.Mounted);
            }
        }
    }
	
	void Update ()
    {
        this.reactorText.text = "Reactor: " + this.reactorMount.Mounted.ToString();
        this.shieldText.text = "Shield: " + this.shieldMount.Mounted.ToString();
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
            items.Add((Reactor)this.reactorMount.Mounted);
        }

        if (this.shieldMount.Mounted != null)
        {
            items.Add((Shield)this.shieldMount.Mounted);
        }

        if (this.hull != null)
        {
            items.Add(this.hull);
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

    public IReactor DetachReactor()
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
            collider.GetComponent<EnemyShip>().DealDamage(COLLISION_DAMAGE);
            DealDamage(COLLISION_DAMAGE);
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
        var remaining = this.shieldMount.Mounted.DealDamage(damage);

        if (this.shieldMount.Mounted.CurrentShield <= 0)
        {
            if (!this.hull.DealDamage(remaining))
            {
                this.hullText.text = "Hull: " + this.hull.ToString();
                Destroy(this.gameObject);
            }
        }
    }
}
