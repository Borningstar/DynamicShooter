using UnityEngine;
using System.Collections;

public class Reactor : MonoBehaviour {

    public float maximumCapacity;
    public float rechargeRate;
    public float rechargeAmount;

    protected float currentCharge;
    protected float nextCharge;

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
