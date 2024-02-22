using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public GameObject goalkeeper;
    Rigidbody2D rb;
    Vector2 destination;
    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = goalkeeper.GetComponent<Rigidbody2D>();
        goalkeeper.transform.position = transform.position;
    }

    private void FixedUpdate()
    {
        if (Controller.selectedPlayer == null) return;
        destination = (GetPlayerPosition() + (Vector2)transform.position) / 2;
        rb.position = Vector2.MoveTowards(rb.position, destination, speed);
    }

    public Vector2 GetPlayerPosition()
    {
        return (Vector2)Controller.selectedPlayer.transform.position;
    }
}
