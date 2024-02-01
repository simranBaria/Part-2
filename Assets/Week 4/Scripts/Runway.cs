using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Runway : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(rigidbody.OverlapPoint(new Vector2(collision.transform.position.x, collision.transform.position.y))) collision.gameObject.GetComponent<Plane>().onLand = true;
    }
}
