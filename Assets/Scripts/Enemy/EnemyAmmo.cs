using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Enemy
{
    public class EnemyAmmo : MonoBehaviour
    {
        public float speed;
        public float damage;

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<ShipController>().DealDamage(damage);
            }
        }
    }
}