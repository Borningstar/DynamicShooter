namespace Assets.Scripts.Enemy.Weapons
{
    using UnityEngine;
    using Vexe.Runtime.Types;

    public class EnemyWeapon : BetterBehaviour, IEnemyWeapon
    {
        public GameObject Ammo { get; protected set; }
        public float FireRate { get; protected set; }
        public float Delay { get; protected set; }
        public float Variance { get; protected set; }

        void Start()
        {
            InvokeRepeating("Fire", Delay + Random.Range(0, Variance), FireRate + Random.Range(0, Variance));
        }

        protected virtual void Fire()
        { 
            LaunchProjectile();
        }

        protected virtual void LaunchProjectile()
        {
            GameObject tempProjectile = Instantiate(Ammo, transform.position, transform.rotation) as GameObject;
        }
    }
}

