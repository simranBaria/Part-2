using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenItem : MonoBehaviour
{
    bool open, locked, itemCollected;
    SpriteRenderer sr;
    public Sprite openSprite, closedSprite, glowOpen, glowClosed;
    public GameObject collectable;

    // Start is called before the first frame update
    void Start()
    {
        open = false;
        sr = GetComponent<SpriteRenderer>();
        locked = false;
        collectable.GetComponent<Collectable>().SetContainerName(gameObject.name);
        itemCollected = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        open = !open;
        if (open)
        {
            sr.sprite = openSprite;
            SendMessage("SetSprite", glowOpen);

            if (!itemCollected)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collectable.SetActive(true);
            }
        }
        else
        {
            sr.sprite = closedSprite;
            SendMessage("SetSprite", glowClosed);
        }
    }

    public void SetLocked(bool state)
    {
        locked = state;
    }

    public void SetItemCollected(bool state)
    {
        itemCollected = state;
    }
}
