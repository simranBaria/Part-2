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
    public RectTransform closedPosition, openPosition;
    public AnimationCurve animationCurve;
    float lerpTimer = 0;
    RectTransform position;
    public GameObject[] slots = new GameObject[4], items = new GameObject[5];
    public int currentEmpty = 0;

    // Start is called before the first frame update
    void Start()
    {
        arrowAnimator = arrow.GetComponent<Animator>();
        position = GetComponent<RectTransform>();

        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(opening)
        {
            float interpolation = animationCurve.Evaluate(lerpTimer);
            position.anchoredPosition = Vector2.Lerp(closedPosition.anchoredPosition, openPosition.anchoredPosition, interpolation);
            lerpTimer += Time.deltaTime;

            if (position.anchoredPosition == openPosition.anchoredPosition)
            {
                lerpTimer = 0;
                opening = false;
            }
        }
        else if(closing)
        {
            float interpolation = animationCurve.Evaluate(lerpTimer);
            position.anchoredPosition = Vector2.Lerp(openPosition.anchoredPosition, closedPosition.anchoredPosition, interpolation);
            lerpTimer += Time.deltaTime;

            if (position.anchoredPosition == closedPosition.anchoredPosition)
            {
                lerpTimer = 0;
                closing = false;
            }
        }
    }

    public void Toggle()
    {
        if (open) CloseInventory();
        else OpenInventory();
    }

    private void OpenInventory()
    {
        open = true;
        arrowAnimator.SetTrigger("Click");
        opening = true;
    }

    private void CloseInventory()
    {
        open = false;
        arrowAnimator.SetTrigger("Click");
        closing = true;
    }

    public void AddItem(string item)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(item.Equals(items[i].name))
            {
                if (currentEmpty >= slots.Length)
                {
                    Debug.Log("Inventory full");
                    return;
                }
                RectTransform itemPosition = items[i].GetComponent<RectTransform>();
                RectTransform slotPosition = slots[currentEmpty].GetComponent<RectTransform>();
                itemPosition.anchoredPosition = slotPosition.anchoredPosition;
                items[i].SetActive(true);
                currentEmpty++;
            }
        }
    }
}
