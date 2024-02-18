using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject arrow;
    Animator arrowAnimator;
    bool open, opening = false, closing = false;
    public RectTransform closedPosition, openPosition;
    public AnimationCurve animationCurve;
    float lerpTimer = 0;
    RectTransform position;

    // Start is called before the first frame update
    void Start()
    {
        arrowAnimator = arrow.GetComponent<Animator>();
        open = false;
        position = GetComponent<RectTransform>();
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
}
