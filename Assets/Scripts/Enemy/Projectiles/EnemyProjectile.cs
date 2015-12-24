namespace Assets.Scripts.Enemy.Projectiles
{
    using UnityEngine;
    using Vexe.Runtime.Types;

    public class EnemyProjectile : BetterBehaviour, IEnemyProjectile
    {
        public float Speed { get; protected set; }
        public float Damage { get; protected set; }

        private Rigidbody rb;

        protected virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * Speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<ShipController>().DealDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}