using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : MonoBehaviour
{
    public Sprite beakerSprite, waterSprite, acidSprite;
    public GameObject icon, inventory, clipboard;
    Image image;
    public bool empty, filledWithWater, filledWithAcid;

    // Start is called before the first frame update
    void Start()
    {
        // Variables for changing the sprite
        image = icon.GetComponent<Image>();
        image.sprite = beakerSprite;
        empty = true;
        filledWithWater = false;
        filledWithAcid = false;
    }

    // Method to fill the beaker with water
    public void FillWithWater()
    {
        // Only fill with water if the beaker is empty
        if(empty)
        {
            // Change sprite
            empty = false;
            filledWithWater = true;
            image.sprite = waterSprite;
            clipboard.SendMessage("ChangeText", "You filled the beaker with water.");
        }
    }

    // Method to fill the beaker with acid
    public void FillWithAcid()
    {
        // Only fill with acid if the beaker has water and the acid item is selected
        if(filledWithWater && inventory.GetComponent<Inventory>().selectedItem.Equals("Acid"))
        {
            // Change sprite
            filledWithWater = false;
            filledWithAcid = true;
            image.sprite = acidSprite;
            clipboard.SendMessage("ChangeText", "You created hydrochloric acid.");

            // Activate the item again
            SendMessage("SetDeactivated", false);

            // Remove the acid from the inventory
            inventory.GetComponent<Inventory>().RemoveItem("Acid");
        }
    }
}
