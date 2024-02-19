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
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        GameObject.Find("Inventory").GetComponent<Inventory>().AddItem(gameObject.name);
        GameObject.Find(containerName).GetComponent<BoxCollider2D>().enabled = true;
        GameObject.Find(containerName).GetComponent<OpenItem>().SetItemCollected(true);
    }

    public void SetContainerName(string name)
    {
        containerName = name;
    }
}
