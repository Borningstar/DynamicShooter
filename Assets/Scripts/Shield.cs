using UnityEngine;
using System.Collections;
using Assets.Scripts.Items.Reactors;

public class Shield : Item {

    public float maximumShield;
    public float rechargeAmount;
    public float rechageDelay;
    public float rechargeRate;
    public float rechargeCost;

    private float nextCharge;
    private float currentShield;
    private Reactor reactor;

    public float CurrentShield
    {
        get { return currentShield; }
    }

	void Start ()
    {
        currentShield = maximumShield;
	}
	
	void Update ()
    {
        if (currentShield < 0)
        {
            currentShield = 0;
        }

        if (reactor != null)
        {
            if (Time.time > nextCharge && currentShield < maximumShield)
            {
                nextCharge = Time.time + rechargeRate;
                if (reactor.Drain(rechargeCost))
                {
                    currentShield += rechargeAmount;
                    if (currentShield > maximumShield)
                    {
                        currentShield = maximumShield;
                    }
                }
            }
        }

    }

    //return left over damage if shield goes into damage, else 0
    public float DealDamage(float damage)
    {
        currentShield -= damage;

        float remaining = 0.0f;

        if (currentShield < 0)
        {
            remaining = Mathf.Abs(currentShield);
            currentShield = 0;
        }

        nextCharge = rechageDelay;

        return remaining;
    }

    public override string ToString()
    {
        return currentShield.ToString("0.0");
    }

    public void ConnectReactor(Reactor reactor)
    {
        this.reactor = reactor;
    }
}
