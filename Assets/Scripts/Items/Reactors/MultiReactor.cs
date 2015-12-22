namespace Assets.Scripts.Items.Reactors
{
    using System.Collections.Generic;
    using UnityEngine;

    class MultiReactor : Reactor
    {
        public List<Reactor> reactors;

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            if (Time.time > nextCharge && CurrentCharge < MaximumCapacity)
            {
                nextCharge = Time.time + RechargeRate;
                CurrentCharge += RechargeAmount;
                if (CurrentCharge > MaximumCapacity)
                {
                    CurrentCharge = MaximumCapacity;
                }
                else
                {
                    foreach (var reactor in reactors)
                    {
                        var toDrain = MaximumCapacity - CurrentCharge;
                        toDrain = reactor.CurrentCharge < toDrain ? reactor.CurrentCharge : toDrain;
                        CurrentCharge += toDrain;
                        reactor.Drain(toDrain);
                        if (CurrentCharge >= MaximumCapacity)
                        {
                            CurrentCharge = MaximumCapacity;
                            break;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            var s = base.ToString();

            if (reactors.Count > 0)
            {
                s += " ( ";
                foreach (var reactor in reactors)
                {
                    s += reactor.ToString() + " ";
                }
                s += ")";
            }

            return s;
        }
    }
}
