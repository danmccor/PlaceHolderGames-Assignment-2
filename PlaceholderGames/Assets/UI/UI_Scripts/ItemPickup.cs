﻿
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        //Add to inventory
        if(wasPickedUp)
        {

            Destroy(gameObject);
        }
    }
    void OnMouseDown()
    {
        Debug.Log("Picking up");
        Interact();
    }

}
