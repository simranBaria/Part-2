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
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closedSprite;
        keyTaken = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(open && !keyTaken)
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
        else
        {
            clipboard.SendMessage("ChangeText", "There's a key behind the bars.");
        }
    }
}
