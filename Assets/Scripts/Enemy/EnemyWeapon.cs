using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Enemy
{
    public class EnemyWeapon : MonoBehaviour
    {
        public GameObject ammo;
        public float fireRate;
        public float delay;
        public float variance;

        void Start()
        {
            InvokeRepeating("Fire", delay + Random.Range(0, variance), fireRate + Random.Range(0, variance));
        }

        protected virtual void Fire()
        { 
            LaunchProjectile();
        }

        protected virtual void LaunchProjectile()
        {
            GameObject tempProjectile = Instantiate(ammo, transform.position, transform.rotation) as GameObject;
        }
    }
}

