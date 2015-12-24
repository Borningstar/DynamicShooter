using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Items.Hulls
{
    public class Hull : Item, IHull
    {
        public float MaximumHull { get; protected set; }

        protected float currentHull;

        void Start()
        {
            currentHull = MaximumHull;
        }

        public void Repair(float amount)
        {
            var healthDifference = MaximumHull - currentHull;
            currentHull += healthDifference > amount ? amount : healthDifference;
        }

        //Returns false when hull destroyed
        public bool DealDamage(float damage)
        {
            currentHull -= damage;

            if (currentHull <= 0)
            {
                currentHull = 0;
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return currentHull.ToString("0.0");
        }
    }
}
