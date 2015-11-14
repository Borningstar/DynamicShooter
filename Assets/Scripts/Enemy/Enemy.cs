using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {

        public float speed;
        public float health;
        public List<GameObject> weapons;

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;

            //weapons[0].GetComponent<EnemyWeapon>().Start();
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
