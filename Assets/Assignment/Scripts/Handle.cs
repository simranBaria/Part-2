using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public GameObject inventory, clipboard, manager;

    private void OnMouseDown()
    {
        // Load the end screen if the player uses the key
        if (inventory.GetComponent<Inventory>().selectedItem.Equals("Key"))
        {
            manager.SendMessage("NextScene");
        }
        else
        {
            clipboard.SendMessage("ChangeText", "The door is locked.");
        }
    }
}
