using UnityEngine;
using System.Collections;

public class Outfitter : MonoBehaviour
{
    public Inventory inventory;
    public ShipController ship;

    void Start()
    {

    }

	private Component CheckMount(ComponentType type)
    {
        return null;
    }

    private Component RemoveComponent(ComponentType type)
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

    private Component RemoveWeapon()
    {
        return null;
    }

    private bool MountComponent(Component component)
    {

        return true;
    }

    private bool MountWeapon(Component component)
    {

        return true;
    }

}

public enum ComponentType { Reactor, Shield, Hull };
