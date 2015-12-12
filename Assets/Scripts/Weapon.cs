using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject ammo;
    public WeaponModifier weaponModifier;

    public float fireRate;

    protected float cost;
    protected float nextFire;
    protected Reactor reactor;

	protected virtual void Start ()
    {
        cost = ammo.GetComponent<Ammo>().cost;

        if (weaponModifier != null)
        {
            fireRate *= weaponModifier.fireRateMod;
            cost *= weaponModifier.costMod;
        }
    }

    public void ConnectReactor(Reactor reactor)
    {
        this.reactor = reactor;
    }

    public virtual bool Fire (Transform shotSpawn)
    {
        if (reactor != null)
        {
            if (Time.time > nextFire)
            {
                if (reactor.Drain(cost))
                {
                    nextFire = Time.time + fireRate;

                    LaunchProjectile(shotSpawn);

                    return true;
                }
            }
        }
        return false;
    }

    protected virtual void LaunchProjectile(Transform shotSpawn)
    {
        GameObject tempProjectile = Instantiate(ammo, shotSpawn.position, Quaternion.Euler(0.0f, 0.0f, 0.0f)) as GameObject;

        ApplyModifiers(tempProjectile);
    }

    protected virtual void ApplyModifiers(GameObject projectile)
    {
        if (weaponModifier != null)
        {
            projectile.GetComponent<Ammo>().damage *= weaponModifier.damageMod;
            var oldScale = projectile.transform.localScale;
            projectile.transform.localScale = Vector3.Scale(weaponModifier.sizeMod, oldScale);
            projectile.GetComponent<Ammo>().speed *= weaponModifier.speedMod;
        }
    }
}
