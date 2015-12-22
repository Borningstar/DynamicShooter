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
        private bool applyDelay;

        void Start()
        {
            CurrentShield = MaximumShield;
            applyDelay = false;
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
                    nextCharge = Time.time + RechargeRate + (applyDelay ? RechageDelay : 0);
                    applyDelay = false;

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
            var remaining = 0.0f;

            CurrentShield -= damage;

            if (CurrentShield < 0)
            {
                remaining = Mathf.Abs(CurrentShield);
                CurrentShield = 0;
            }

            applyDelay = true;

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
