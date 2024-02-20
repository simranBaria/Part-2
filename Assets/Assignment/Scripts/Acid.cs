using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    public GameObject beaker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to deactivate the beaker as a clickable icon when selected
    public void Selected()
    {
        // Only deactivate if the beaker is filled with water
        if (gameObject.GetComponent<InventoryItem>().selected && beaker.GetComponent<Beaker>().filledWithWater)
        {
            beaker.GetComponent<InventoryItem>().SetDeactivated(true);
        }
        // Activate the beaker again when not selected
        else if (!gameObject.GetComponent<InventoryItem>().selected)
        {
            beaker.GetComponent<InventoryItem>().SetDeactivated(false);
        }
    }
}
