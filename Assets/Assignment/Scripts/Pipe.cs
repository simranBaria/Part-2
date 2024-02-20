using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject inventory, clipboard;
    public bool pipeFixed = false;

    private void OnMouseDown()
    {
        // The pipe is fixed
        if(pipeFixed)
        {
            clipboard.SendMessage("ChangeText", "The pipe is fixed.");
            return;
        }

        // Check if the wrench is selected
        if(inventory.GetComponent<Inventory>().selectedItem.Equals("Wrench"))
        {
            // Fix the pipe
            pipeFixed = true;
            clipboard.SendMessage("ChangeText", "You fixed the pipe.");
            inventory.GetComponent<Inventory>().RemoveItem("Wrench");
        }
        // Pipe is broken
        else
        {
            clipboard.SendMessage("ChangeText", "The pipe is broken.");
        }
    }
}
