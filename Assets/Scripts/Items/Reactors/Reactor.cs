namespace Assets.Scripts.Items.Reactors
{
    using UnityEngine;

    public class Reactor : Item, IReactor
    {
        public float MaximumCapacity { get; protected set; }
        public float RechargeRate { get; protected set; }
        public float RechargeAmount { get; protected set; }
        public float CurrentCharge { get; protected set; }

        protected float nextCharge;

        protected virtual void Start()
        {
            CurrentCharge = MaximumCapacity;
        }

        protected virtual void Update()
        {
            if (Time.time > nextCharge && CurrentCharge < MaximumCapacity)
            {
                nextCharge = Time.time + RechargeRate;
                CurrentCharge += RechargeAmount;
                if (CurrentCharge > MaximumCapacity)
                {
                    CurrentCharge = MaximumCapacity;
                }
            }
        }

        public virtual bool Drain(float amount)
        {
            if (amount <= CurrentCharge)
            {
                CurrentCharge -= amount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return CurrentCharge.ToString("0.0");
        }
    }
}