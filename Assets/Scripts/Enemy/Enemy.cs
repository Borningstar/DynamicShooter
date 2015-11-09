using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {

        public float speed;
        public float health;
        public List<EnemyWeapon> weapons;

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;
        }

        public bool DealDamage(float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Destroy(this.gameObject);
                return false;
            }
            return false;
        }
    }
}
