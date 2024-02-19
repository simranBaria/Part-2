using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public GameObject glow, inventory;
    Animator animator;
    public bool selected, deactivated;

    // Start is called before the first frame update
    void Start()
    {
        // Set the item to unselected
        selected = false;
        animator = glow.GetComponent<Animator>();
        deactivated = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to change whether the item is selected
    public void ItemSelected()
    {
        if (deactivated) return;

        if(selected)
        {
            // Turn off the glowing animation
            animator.SetTrigger("Unselected");
            selected = false;

            // Tell the inventory to deselect this item
            inventory.GetComponent<Inventory>().DeselectItem();
        }
        else
        {
            // Turn on the glowing animation
            animator.SetTrigger("Selected");
            selected = true;

            // Tell the inventory to select this item
            inventory.GetComponent<Inventory>().SelectItem(gameObject.name);
        }
    }

    public void SetDeactivated(bool state)
    {
        deactivated = state;
    }
}
