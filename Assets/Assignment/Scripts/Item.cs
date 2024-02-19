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
        glow.GetComponent<GameObject>();
        animator = glow.GetComponent<Animator>();
        glowSR = glow.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        animator.SetTrigger("Hovering");
    }

    private void OnMouseExit()
    {
        animator.SetTrigger("Stop");
    }

    public void SetSprite(Sprite newSprite)
    {
        glowSR.sprite = newSprite;
    }
}
