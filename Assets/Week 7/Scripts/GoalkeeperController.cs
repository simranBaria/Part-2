using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public GameObject goalkeeper;
    Rigidbody2D rb;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = goalkeeper.GetComponent<Rigidbody2D>();
        goalkeeper.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Controller.selectedPlayer == null) return;
        rb.position = (GetPlayerPosition() + (Vector2)transform.position) / 2;
    }

    public Vector2 GetPlayerPosition()
    {
        return (Vector2)Controller.selectedPlayer.transform.position;
    }
}
