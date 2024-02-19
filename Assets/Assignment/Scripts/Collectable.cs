using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string containerName;

    // Start is called before the first frame update
    void Start()
    {
        // Turn off the item
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // Destory the item and send it to the inventory
        Destroy(gameObject);
        GameObject.Find("Inventory").GetComponent<Inventory>().AddItem(gameObject.name);

        // Tell the container that the item was collected
        GameObject.Find(containerName).GetComponent<BoxCollider2D>().enabled = true;
        GameObject.Find(containerName).GetComponent<OpenItem>().SetItemCollected(true);
    }

    // Method to set the container
    public void SetContainerName(string name)
    {
        containerName = name;
    }
}
