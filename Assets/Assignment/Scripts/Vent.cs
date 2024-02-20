using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public GameObject inventory, beaker, clipboard, key;
    public bool open = false;
    SpriteRenderer sr;
    public Sprite closedSprite, openSprite;
    bool keyTaken;

    // Start is called before the first frame update
    void Start()
    {
        // Sprite variables
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closedSprite;

        // Decides whether clicking on the vent should give the key or display a message
        keyTaken = false;
    }

    private void OnMouseDown()
    {
        // Only display messages if key isn't taken yet
        if (!keyTaken)
        {
            // Give the key if open
            if (open)
            {
                keyTaken = true;
                key.SetActive(true);
                key.SendMessage("ShowItem", true);
                return;
            }

            // Check if the beaker is selected
            if (inventory.GetComponent<Inventory>().selectedItem.Equals("Beaker") && beaker.GetComponent<Beaker>().filledWithAcid)
            {
                // Melt the bars
                open = true;
                clipboard.SendMessage("ChangeText", "You melted the bars.");
                sr.sprite = openSprite;
                inventory.GetComponent<Inventory>().RemoveItem("Beaker");
            }
            // Vent is still closed
            else clipboard.SendMessage("ChangeText", "There's a key behind the bars.");
        }
    }
}
