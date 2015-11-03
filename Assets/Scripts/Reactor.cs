using UnityEngine;
using System.Collections;

public class Reactor : MonoBehaviour {

    public float maximumCapacity;
    public float rechargeRate;
    public float rechargeAmount;

    private float currentCharge;
    private float nextCharge;

    public virtual void Start()
    {
        currentCharge = maximumCapacity;
    }

    public virtual void Update()
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
        if (amount < currentCharge)
        {
            currentCharge -= amount;
            return true;
        }
        return false;
    }

    public virtual float CurrentCharge
    {
        get
        {
            return currentCharge;
        }
    }
}
