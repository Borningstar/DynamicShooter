using UnityEngine;
using System.Collections;
using Assets.Scripts.Items;

public class Outfitter : MonoBehaviour
{
    public Inventory inventory;
    public ShipController ship;

    void Start()
    {

    }

	private Item CheckMount(ComponentType type)
    {
        return null;
    }

    private Item RemoveComponent(ComponentType type)
    {
        switch(type)
        {
            case ComponentType.Hull:
                break;
            case ComponentType.Reactor:
                break;
            case ComponentType.Shield:
                break;
        }

        return null;
    }

    private Item RemoveWeapon()
    {
        return null;
    }

    private bool MountComponent(Item component)
    {

        return true;
    }

    private bool MountWeapon(Item component)
    {

        return true;
    }

}

public enum ComponentType { Reactor, Shield, Hull };
