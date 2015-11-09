using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Enemy
{
    public class EnemyWeapon : MonoBehaviour
    {
        public GameObject ammo;
        public float fireRate;
        public float delay;

        void Start()
        {
            InvokeRepeating("Fire", delay, fireRate);
        }

        public virtual void Fire()
        { 
            LaunchProjectile();
        }

        protected virtual void LaunchProjectile()
        {
            GameObject tempProjectile = Instantiate(ammo, transform.position, transform.rotation) as GameObject;
        }
    }
}

