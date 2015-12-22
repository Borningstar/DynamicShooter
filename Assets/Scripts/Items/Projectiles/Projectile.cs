namespace Assets.Scripts.Items.Projectiles
{
    using UnityEngine;

    public class Projectile : Item, IProjectile
    {
        public float Cost { get; protected set; }

        public float Speed { get; set; }

        public float Damage { get; set; }

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * Speed;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                //TODO: Deal damage to enemy when done
            //    other.GetComponent<Enemy>().DealDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}