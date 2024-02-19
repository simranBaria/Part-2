using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public GameObject inventory;

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
        if (inventory.GetComponent<Inventory>().selectedItem.Equals("Key"))
        {
            Debug.Log("You escaped!");
        }
        else
        {
            Debug.Log("The door is locked");
        }
    }
}
