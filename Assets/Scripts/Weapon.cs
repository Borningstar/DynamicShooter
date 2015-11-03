using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public GameObject projectileObject;
    public float fireRate;

    private float cost;
    private float nextFire;

	void Start ()
    {
        cost = projectileObject.GetComponent<Projectile>().Cost;
	}
	
	void Update ()
    {
	
	}

    public bool Fire (Transform shotSpawn, Reactor reactor)
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
