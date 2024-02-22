using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Color selectedColour, unselectedColour;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        unselectedColour = sr.color;
        Selected(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Selected(true);
    }

    public void Selected(bool isSelected)
    {
        if(isSelected)
        {
            sr.color = selectedColour;
        }
        else
        {
            sr.color = unselectedColour;
        }
    }
}
