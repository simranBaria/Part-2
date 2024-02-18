using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInteractable : MonoBehaviour
{
    bool open;
    SpriteRenderer objectSR, glowSR;
    public Sprite openSprite, closedSprite, glowOpen, glowClosed;
    public GameObject glow;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        open = false;
        objectSR = GetComponent<SpriteRenderer>();
        glow.GetComponent<GameObject>();
        animator = glow.GetComponent<Animator>();
        glowSR = glow.GetComponent<SpriteRenderer>();
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
            objectSR.sprite = openSprite;
            glowSR.sprite = glowOpen;
        }
        else
        {
            objectSR.sprite = closedSprite;
            glowSR.sprite = glowClosed;
        }
    }

    private void OnMouseEnter()
    {
        animator.SetTrigger("Hovering");
    }

    private void OnMouseExit()
    {
        animator.SetTrigger("Stop");
    }
}
