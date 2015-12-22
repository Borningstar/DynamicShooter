using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory;

    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    public Item TakeItem(int index)
    {
        return inventory[index];
    }
}
