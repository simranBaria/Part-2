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
    public static int score { get; private set; }

    void Start()
    {
        SetPosition(kickOffPoint.transform);
        score = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetPosition(kickOffPoint.transform);
        rb.velocity = Vector2.zero;
        score++;
    }

    public void SetPosition(Transform position)
    {
        transform.position = position.position;
    }
}
