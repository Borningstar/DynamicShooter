using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class FanGun : Weapon
    {
        public int numShots;
        public int angle;

        private List<Quaternion> shotDirections;
        
        protected override void Start()
        {
            base.Start();

            shotDirections = CalculateDirections();
        }

        private List<Quaternion> CalculateDirections()
        {
            float segment = angle / (numShots - 1);
            float adjustment = angle / 2 ;
            List<Quaternion> directions = new List<Quaternion>();

            for(int i = 0; i < numShots; i++)
            {
                directions.Add(Quaternion.Euler(0.0f, segment * i - adjustment, 0.0f));
            }

            return directions;
        }

        public override bool Fire(Transform shotSpawn)
        {
            if (reactor != null)
            {
                if (Time.time > nextFire)
                {
                    if (reactor.Drain(cost * numShots))
                    {
                        nextFire = Time.time + fireRate;

                        LaunchProjectile(shotSpawn);

                        return true;
                    }
                }
            }

            return false;
        }

        protected override void LaunchProjectile(Transform shotSpawn)
        {
            foreach (var shotRotation in shotDirections)
            {
                GameObject tempProjectile = Instantiate(ammo, shotSpawn.position, shotRotation) as GameObject;

                ApplyModifiers(tempProjectile);
            }
        }
    }
}
