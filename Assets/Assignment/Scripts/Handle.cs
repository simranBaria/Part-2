using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public GameObject inventory, clipboard, manager;

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
            manager.SendMessage("NextScene");
        }
        else
        {
            clipboard.SendMessage("ChangeText", "The door is locked.");
        }
    }
}
