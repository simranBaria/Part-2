using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public GameObject inventory, pipe, beaker, clipboard;

    private void OnMouseDown()
    {
        // Check if the pipe is fixed
        if(pipe.GetComponent<Pipe>().pipeFixed)
        {
            // Check if the beaker is selected
            if(inventory.GetComponent<Inventory>().selectedItem.Equals("Beaker"))
            {
                // Fill the beaker with water
                beaker.SendMessage("FillWithWater");
            }
            // The sink is working
            else clipboard.SendMessage("ChangeText", "The water is running now.");
        }
        // Sink is broken
        else clipboard.SendMessage("ChangeText", "The sink isn't working.");
    }
}
