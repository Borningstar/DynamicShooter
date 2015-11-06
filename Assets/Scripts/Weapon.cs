using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public GameObject projectileObject;
    public GameObject weaponModifierObject;
    public float fireRate;

    protected float cost;
    protected float nextFire;
    protected WeaponModifier weaponModifier;

	protected virtual void Start ()
    {
        cost = projectileObject.GetComponent<Projectile>().cost;

        if (weaponModifierObject != null)
        {
            weaponModifier = weaponModifierObject.GetComponent<WeaponModifier>();
            fireRate *= weaponModifier.fireRateMod;
            cost *= weaponModifier.costMod;
        }

    }

    public virtual bool Fire (Transform shotSpawn, Reactor reactor)
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

        return false;
    }

    protected virtual void LaunchProjectile(Transform shotSpawn)
    {
        GameObject tempProjectile = Instantiate(projectileObject, shotSpawn.position, shotSpawn.rotation) as GameObject;

        ApplyModifiers(tempProjectile);
    }

    protected virtual void ApplyModifiers(GameObject projectile)
    {
        if (weaponModifierObject != null)
        {
            weaponModifier = weaponModifierObject.GetComponent<WeaponModifier>();
            projectile.GetComponent<Projectile>().damage *= weaponModifier.damageMod;
            projectile.GetComponent<Projectile>().speed *= weaponModifier.speedMod;
            projectile.transform.localScale.Scale(weaponModifier.sizeMod);
        }
    }
}
