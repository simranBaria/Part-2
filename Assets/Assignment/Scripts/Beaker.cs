using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : MonoBehaviour
{
    public Sprite beakerSprite, waterSprite, acidSprite;
    public GameObject icon, inventory;
    Image image;
    public bool empty, filledWithWater, filledWithAcid;

    // Start is called before the first frame update
    void Start()
    {
        image = icon.GetComponent<Image>();
        image.sprite = beakerSprite;
        empty = true;
        filledWithWater = false;
        filledWithAcid = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillWithWater()
    {
        if(empty)
        {
            empty = false;
            filledWithWater = true;
            image.sprite = waterSprite;
            Debug.Log("You filled the beaker with water");
        }
    }

    public void FillWithAcid()
    {
        if(filledWithWater && inventory.GetComponent<Inventory>().selectedItem.Equals("Acid"))
        {
            filledWithWater = false;
            filledWithAcid = true;
            image.sprite = acidSprite;
            Debug.Log("You created hydrochloric acid");
            SendMessage("SetDeactivated", false);
            inventory.GetComponent<Inventory>().RemoveItem("Acid");
        }
    }
}
