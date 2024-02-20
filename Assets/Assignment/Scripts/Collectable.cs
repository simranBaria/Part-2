using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string containerName;
    public GameObject clipboard, inventory;
    bool showcase, sendToInventory;
    Vector2 movement, middle, end;
    float speed = 10;
    Rigidbody2D rb;
    public AnimationCurve animationCurve;

    // Start is called before the first frame update
    void Start()
    {
        // Turn off the item
        gameObject.SetActive(false);
        showcase = false;
        middle = Vector2.zero;
        end = new Vector2(-5, 5);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Animation to show the item
        if(showcase)
        {
            movement = middle - (Vector2)transform.position;

            if (movement.magnitude > 0.1)
            {
                float velocity = speed * animationCurve.Evaluate(Time.deltaTime);
                rb.MovePosition(rb.position + velocity * Time.deltaTime * movement.normalized);
                
            }
            else
            {
                // Animation done
                showcase = false;
                sendToInventory = true;
            }
        }
        // Animation to send the item to the inventory
        if(sendToInventory)
        {
            movement = end - (Vector2)transform.position;

            if (movement.magnitude > 0.1)
            {
                float velocity = speed * animationCurve.Evaluate(Time.deltaTime);
                rb.MovePosition(rb.position + velocity * Time.deltaTime * movement.normalized);
            }
            else
            {
                // Animation done
                sendToInventory = false;

                // Destroy the game object and show it in the inventory
                GameObject.Find("Inventory").GetComponent<Inventory>().AddItem(gameObject.name);
                Destroy(gameObject);

                // Show message that item was collected
                ShowMessage();
            }
        }
    }

    private void OnMouseDown()
    {
        // Send the item to the inventory
        ShowItem(true);

        // Tell the container that the item was collected
        GameObject.Find(containerName).GetComponent<BoxCollider2D>().enabled = true;
        GameObject.Find(containerName).GetComponent<OpenItem>().SetItemCollected(true);

    }

    // Method to set the container
    public void SetContainerName(string name)
    {
        containerName = name;
    }

    private void ShowMessage()
    {
        switch(gameObject.name)
        {
            case "Beaker":
                clipboard.SendMessage("ChangeText", "You got a beaker.");
                break;

            case "Wrench":
                clipboard.SendMessage("ChangeText", "You got a wrench.");
                break;

            case "Password":
                clipboard.SendMessage("ChangeText", "A note was stuck to the cabinet, there's a password scribbled on it.");
                break;

            case "Acid":
                clipboard.SendMessage("ChangeText", "You got a bottle of hydrogen chloride.");
                break;

            case "Key":
                clipboard.SendMessage("ChangeText", "You got the key!");
                break;
        }
    }

    public void ShowItem(bool show)
    {
        showcase = show;
    }
}
