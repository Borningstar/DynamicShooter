namespace Assets.Scripts.Components.Reactors
{
    using UnityEngine;

    public class Reactor : MonoBehaviour, IComponent
    {

        public float maximumCapacity;
        public float rechargeRate;
        public float rechargeAmount;

        protected float currentCharge;
        protected float nextCharge;

        [SerializeField]
        protected string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [SerializeField]
        protected string prefix;
        public string Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        [SerializeField]
        protected string suffix;
        public string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }

        protected virtual void Start()
        {
            currentCharge = maximumCapacity;
        }

        protected virtual void Update()
        {
            if (Time.time > nextCharge && currentCharge < maximumCapacity)
            {
                nextCharge = Time.time + rechargeRate;
                currentCharge += rechargeAmount;
                if (currentCharge > maximumCapacity)
                {
                    currentCharge = maximumCapacity;
                }
            }
        }

        public virtual bool Drain(float amount)
        {
            if (amount <= currentCharge)
            {
                currentCharge -= amount;
                return true;
            }
            return false;
        }

        public float CurrentCharge
        {
            get
            {
                return currentCharge;
            }
        }

        public override string ToString()
        {
            return currentCharge.ToString("0.0");
        }
    }
}
