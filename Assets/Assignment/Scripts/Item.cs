using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    SpriteRenderer glowSR;
    public GameObject glow;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = glow.GetComponent<Animator>();
        glowSR = glow.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        // Start the glowing animation when the mouse hovers over the object
        animator.SetTrigger("Hovering");
    }

    private void OnMouseExit()
    {
        // Stop the glowing animation when the mouse leaves the object
        animator.SetTrigger("Stop");
    }

    // Method to change the glowing sprite
    public void SetSprite(Sprite newSprite)
    {
        glowSR.sprite = newSprite;
    }
}
