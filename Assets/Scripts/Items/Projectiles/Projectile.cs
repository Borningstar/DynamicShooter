namespace Assets.Scripts.Items.Projectiles
{
    using UnityEngine;

    public class Projectile : Item, IProjectile
    {
        [SerializeField]
        protected float cost;
        public float Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        [SerializeField]
        protected float speed;
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        [SerializeField]
        protected float damage;
        public float Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;
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