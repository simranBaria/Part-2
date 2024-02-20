using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    public GameObject inventory, safe, clipboard;
    public bool unlocked = false;
    SpriteRenderer sr;
    public Sprite offSprite, onSprite;

    // Start is called before the first frame update
    void Start()
    {
        // Sprite variables
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = offSprite;
    }

    private void OnMouseDown()
    {
        // Check if the laptop is unlocked
        if (unlocked)
        {
            // Unlock the safe
            clipboard.SendMessage("ChangeText", "You found a safe code in the laptop's files.");
            safe.GetComponent<OpenItem>().locked = false;
            return;
        }

        // Check if the passowrd is selected
        if (inventory.GetComponent<Inventory>().selectedItem.Equals("Password"))
        {
            // Unlock the laptop
            unlocked = true;
            clipboard.SendMessage("ChangeText", "You turned on the laptop.");
            sr.sprite = onSprite;
            inventory.GetComponent<Inventory>().RemoveItem("Password");
        }
        // Laptop is locked
        else clipboard.SendMessage("ChangeText", "You don't know the password.");
    }
}
