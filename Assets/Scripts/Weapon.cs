using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public GameObject projectileObject;
    public GameObject weaponModifierObject;
    public float fireRate;

    protected float cost;
    protected float nextFire;

	protected virtual void Start ()
    {
        cost = projectileObject.GetComponent<Projectile>().cost;
	}

    public virtual bool Fire (Transform shotSpawn, Reactor reactor)
    {
        if (Time.time > nextFire)
        {
            if (reactor.Drain(cost))
            {
                nextFire = Time.time + fireRate;
                Instantiate(projectileObject, shotSpawn.position, shotSpawn.rotation);
                return true;
            }
        }

        return false;
    }
}
