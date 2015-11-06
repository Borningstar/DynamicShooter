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

        protected override void Start()
        {
            //base.Start();

            reactors = new List<Reactor>();

            foreach(var reactorSocket in reactorSockets)
            {
                var reactor = reactorSocket.GetComponent<Reactor>();
                reactors.Add(reactor);
            }
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
                        currentCharge += reactor.CurrentCharge;
                        reactor.Drain(reactor.CurrentCharge);
                        if (currentCharge > maximumCapacity)
                        {
                            currentCharge = maximumCapacity;
                            break;
                        }
                    }
                }
            }
        }

    }
}
