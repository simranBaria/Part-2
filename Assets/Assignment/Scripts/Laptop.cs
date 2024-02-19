using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    public GameObject inventory, safe;
    public bool unlocked = false;
    SpriteRenderer sr;
    public Sprite offSprite, onSprite;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = offSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // Check if the laptop is unlocked
        if (unlocked)
        {
            // Unlock the safe
            Debug.Log("The laptop has a safe code");
            safe.GetComponent<OpenItem>().locked = false;
            return;
        }

        // Check if the passowrd is selected
        if (inventory.GetComponent<Inventory>().selectedItem.Equals("Password"))
        {
            // Unlock the laptop
            unlocked = true;
            Debug.Log("You turned on the laptop");
            sr.sprite = onSprite;
            inventory.GetComponent<Inventory>().RemoveItem("Password");
        }
        else
        {
            Debug.Log("You don't know the password");
        }
    }
}
