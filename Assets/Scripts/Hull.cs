﻿using UnityEngine;
using System.Collections;

public class Hull : MonoBehaviour
{

    public float maximumHull;

    protected float currentHull;

    void Start()
    {
        currentHull = maximumHull;
    }

    public void Repair(float amount)
    {
        var healthDifference = maximumHull - currentHull;
        currentHull += healthDifference > amount ? amount : healthDifference;
    }

    //Returns false when hull destroyed
    public bool DealDamage(float damage)
    {
        maximumHull -= currentHull;

        if (currentHull <= 0)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return currentHull.ToString("0.0");
    }
}