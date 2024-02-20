using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject arrow;
    Animator arrowAnimator;
    bool open = false, opening = false, closing = false;
    public bool hasItemSelected = false;
    public string selectedItem = "";
    public RectTransform closedPosition, openPosition;
    public AnimationCurve animationCurve;
    float lerpTimer = 0;
    RectTransform position;
    public GameObject[] slots = new GameObject[4], items = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        arrowAnimator = arrow.GetComponent<Animator>();
        position = GetComponent<RectTransform>();

        // Deactivate all items
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Opening animation
        if (opening)
        {
            float interpolation = animationCurve.Evaluate(lerpTimer);
            position.anchoredPosition = Vector2.Lerp(closedPosition.anchoredPosition, openPosition.anchoredPosition, interpolation);
            lerpTimer += Time.deltaTime;

            // Stop animation once the inventory has reached it's position
            if (position.anchoredPosition == openPosition.anchoredPosition)
            {
                lerpTimer = 0;
                opening = false;
            }
        }
        // Closing animation
        else if (closing)
        {
            float interpolation = animationCurve.Evaluate(lerpTimer);
            position.anchoredPosition = Vector2.Lerp(openPosition.anchoredPosition, closedPosition.anchoredPosition, interpolation);
            lerpTimer += Time.deltaTime;

            // Stop the animation once the inventory has reached it's position
            if (position.anchoredPosition == closedPosition.anchoredPosition)
            {
                lerpTimer = 0;
                closing = false;
            }
        }
    }

    // Method to toggle inventory
    public void Toggle()
    {
        if (open) CloseInventory();
        else OpenInventory();
    }

    // Method to open the inventory
    private void OpenInventory()
    {
        open = true;
        arrowAnimator.SetTrigger("Click");
        opening = true;
    }

    // Method to close the inventory
    private void CloseInventory()
    {
        open = false;
        arrowAnimator.SetTrigger("Click");
        closing = true;
    }

    // Method to add an item to the inventory
    public void AddItem(string item)
    {
        // Find which item is being added
        for (int i = 0; i < items.Length; i++)
        {
            if (item.Equals(items[i].name))
            {
                // Check if the inventory is full
                // In the game this should never happen but this is here for testing and just in case
                if (EmptySlotLocation() >= slots.Length)
                {
                    Debug.Log("Inventory full");
                    return;
                }

                // Put the item in the inventory
                RectTransform itemPosition = items[i].GetComponent<RectTransform>();
                RectTransform slotPosition = slots[EmptySlotLocation()].GetComponent<RectTransform>();
                itemPosition.anchoredPosition = slotPosition.anchoredPosition;
                items[i].SetActive(true);
            }
        }
    }

    // Method to select an item
    public void SelectItem(string item)
    {
        // Check if there is already an item selected
        if(hasItemSelected)
        {
            // Find the selected item
            for (int i = 0; i < items.Length; i++)
            {
                // Deselect it
                if (items[i].name.Equals(selectedItem))
                {
                    items[i].GetComponent<InventoryItem>().ItemSelected();
                }
            }
        }

        // Select the item
        selectedItem = item;
        hasItemSelected = true;
    }

    // Method to deselect an item
    public void DeselectItem()
    {
        selectedItem = "";
        hasItemSelected = false;
    }

    public void RemoveItem(string item)
    {
        // Find the item
        for (int i = 0; i < items.Length; i++)
        {
            // Destroy it
            if (items[i].name.Equals(selectedItem))
            {
                items[i].SetActive(false);
                items[i].GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                selectedItem = "";
            }
        }
    }

    public int EmptySlotLocation()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (IsSlotEmpty(i)) return i;
        }

        return 5;
    }

    public bool IsSlotEmpty(int slot)
    {
        for (int i = 0; i < items.Length; i++)
        {
            RectTransform slotPosition = slots[slot].GetComponent<RectTransform>();
            RectTransform itemPosition = items[i].GetComponent<RectTransform>();

            if (slotPosition.anchoredPosition == itemPosition.anchoredPosition) return false;
        }

        return true;
    }

    public Vector2 GetEmptySlotPosition()
    {
        RectTransform position = slots[EmptySlotLocation()].GetComponent<RectTransform>();
        return Camera.main.WorldToScreenPoint(position.position);
    }
}