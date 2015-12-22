namespace Assets.Scripts.Items.Shields
{
    using UnityEngine;
    using Reactors;

    public class Shield : Item, IShield
    {
        public float MaximumShield { get; protected set; }
        public float RechargeAmount { get; protected set; }
        public float RechageDelay { get; protected set; }
        public float RechargeRate { get; protected set; }
        public float RechargeCost { get; protected set; }
        public float CurrentShield { get; protected set; }

        private float nextCharge;
        private Reactor reactor;

        void Start()
        {
            CurrentShield = MaximumShield;
        }

        void Update()
        {
            if (CurrentShield < 0)
            {
                CurrentShield = 0;
            }

            if (reactor != null)
            {
                if (Time.time > nextCharge && CurrentShield < MaximumShield)
                {
                    nextCharge = Time.time + RechargeRate;
                    if (reactor.Drain(RechargeCost))
                    {
                        CurrentShield += RechargeAmount;
                        if (CurrentShield > MaximumShield)
                        {
                            CurrentShield = MaximumShield;
                        }
                    }
                }
            }

        }

        //return left over damage if shield goes into damage, else 0
        public float DealDamage(float damage)
        {
            CurrentShield -= damage;

            float remaining = 0.0f;

            if (CurrentShield < 0)
            {
                remaining = Mathf.Abs(CurrentShield);
                CurrentShield = 0;
            }

            nextCharge = RechageDelay;

            return remaining;
        }

        public override string ToString()
        {
            return CurrentShield.ToString("0.0");
        }

        public void ConnectReactor(Reactor reactor)
        {
            this.reactor = reactor;
        }
    }
}
