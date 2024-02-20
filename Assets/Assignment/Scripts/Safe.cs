using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    public GameObject clipboard;

    // Start is called before the first frame update
    void Start()
    {
        // Set the safe to locked
        gameObject.GetComponent<OpenItem>().locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // Check if the safe is locked
        if(gameObject.GetComponent<OpenItem>().locked)
        {
            clipboard.SendMessage("ChangeText", "The safe is locked.");
        }
    }
}
