namespace Assets.Scripts.Enemy.Ships
{
    using Weapons;
    using System.Collections.Generic;
    using UnityEngine;
    using Vexe.Runtime.Types;

    public class EnemyShip : BetterBehaviour, IEnemyShip
    {
        public float Speed { get; protected set; }
        public float Health { get; protected set; }
        public List<GameObject> Weapons { get; protected set; }

        protected Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * Speed;
        }

        public bool DealDamage(float damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Destroy(this.gameObject);
                return false;
            }
            return false;
        }
    }
}