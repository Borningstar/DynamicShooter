using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Component> inventory;

    public void AddItem(Component item)
    {
        inventory.Add(item);
    }

    public Component TakeItem(int index)
    {
        return inventory[index];
    }
}
