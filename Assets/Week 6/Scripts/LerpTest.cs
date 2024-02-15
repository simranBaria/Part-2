using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public float lerpTimer;
    public AnimationCurve animationCurve;
    SpriteRenderer sr;
    public Color startColour;
    public Color endColour;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = animationCurve.Evaluate(lerpTimer);
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, interpolation);
        lerpTimer += Time.deltaTime;

        sr.color = Color.Lerp(startColour, endColour, interpolation);
    }
}
