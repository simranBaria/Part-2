using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenItem : MonoBehaviour
{
    bool open, itemCollected;
    public bool locked = false;
    SpriteRenderer sr;
    public Sprite openSprite, closedSprite, glowOpen, glowClosed;
    public GameObject collectable;

    // Start is called before the first frame update
    void Start()
    {
        // Set the container to closed
        open = false;
        sr = GetComponent<SpriteRenderer>();
        collectable.GetComponent<Collectable>().SetContainerName(gameObject.name);
        itemCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // Do not open if the container is locked
        if (locked) return;

        open = !open;
        if (open)
        {
            // Change the sprite to open
            sr.sprite = openSprite;
            SendMessage("SetSprite", glowOpen);

            if (!itemCollected)
            {
                // Disable the collider so the player can click on the item inside
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                // Set the item to visible
                collectable.SetActive(true);
            }
        }
        else
        {
            // Change the sprite to closed
            sr.sprite = closedSprite;
            SendMessage("SetSprite", glowClosed);
        }
    }

    // Method to set whether the container is locked
    public void SetLocked(bool state)
    {
        locked = state;
    }

    // Method to set whether the item inside the container has been collected
    public void SetItemCollected(bool state)
    {
        itemCollected = state;
    }
}
