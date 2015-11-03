using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class MultiReactor : Reactor
    {
        public GameObject[] reactorSockets;

        private List<Reactor> reactors;
        private float currentCharge;

        public override void Start()
        {
            reactors = new List<Reactor>();

            foreach(var reactorSocket in reactorSockets)
            {
                var reactor = reactorSocket.GetComponent<Reactor>();
                reactors.Add(reactor);
                maximumCapacity += reactor.maximumCapacity;
            }
        }

        public override void Update()
        {
            currentCharge = 0;
            foreach(var reactor in reactors)
            {
                currentCharge += reactor.CurrentCharge;
            }
        }

        public override bool Drain(float amount)
        {
            foreach(var reactor in reactors)
            {
                if (reactor.Drain(amount))
                {
                    currentCharge -= amount;
                    return true;
                }
            }
            return false;
        }

        public override float CurrentCharge
        {
            get
            {
                return currentCharge;
            }
        }
    }
}
