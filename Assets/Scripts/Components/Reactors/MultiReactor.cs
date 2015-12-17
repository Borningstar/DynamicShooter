namespace Assets.Scripts.Components.Reactors
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
            if (Time.time > nextCharge && currentCharge < maximumCapacity)
            {
                nextCharge = Time.time + rechargeRate;
                currentCharge += rechargeAmount;
                if (currentCharge > maximumCapacity)
                {
                    currentCharge = maximumCapacity;
                }
                else
                {
                    foreach (var reactor in reactors)
                    {
                        var toDrain = maximumCapacity - currentCharge;
                        toDrain = reactor.CurrentCharge < toDrain ? reactor.CurrentCharge : toDrain;
                        currentCharge += toDrain;
                        reactor.Drain(toDrain);
                        if (currentCharge >= maximumCapacity)
                        {
                            currentCharge = maximumCapacity;
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
