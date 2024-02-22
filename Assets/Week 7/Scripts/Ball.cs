using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    public GameObject kickOffPoint;
    Rigidbody2D rb;

    void Start()
    {
        SetPosition(kickOffPoint.transform);
        Controller.SetScore(0);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetPosition(kickOffPoint.transform);
        rb.velocity = Vector2.zero;
        Controller.SetScore(Controller.score + 1);
    }

    public void SetPosition(Transform position)
    {
        transform.position = position.position;
    }
}
