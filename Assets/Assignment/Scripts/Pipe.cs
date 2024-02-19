using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject inventory;
    public bool pipeFixed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // The pipe is fixed
        if(pipeFixed)
        {
            Debug.Log("The pipe is fixed");
            return;
        }

        // Check if the wrench is selected
        if(inventory.GetComponent<Inventory>().selectedItem.Equals("Wrench"))
        {
            // Fix the pipe
            pipeFixed = true;
            Debug.Log("You fixed the pipe");
            
        }
        else
        {
            Debug.Log("The pipe is broken");
        }
    }
}
