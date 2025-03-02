using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody;
    Vector2 currentPosition;
    public float speed = 1;
    public AnimationCurve landing;
    private float timerValue;
    public Sprite[] sprites = new Sprite[4];
    SpriteRenderer spriteRenderer;
    public float tooClose = 1f;
    public bool onLand = false;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rigidbody = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        transform.Rotate(0, 0, Random.Range(0, 360));
        speed = Random.Range(1, 3);

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, 3)];
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        
        if(points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }

        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        if(onLand)
        {
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);

            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
                GameObject.Find("Runway").GetComponent<Runway>().playerScore++;
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);
                
                for(int i = 0; i < lineRenderer.positionCount - 2; i++) lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));

                lineRenderer.positionCount--;
            }
        }
    }

    void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(lastPosition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.ToString().Equals(this.gameObject.ToString())) spriteRenderer.color = Color.red;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.ToString().Equals(this.gameObject.ToString())) if (Vector3.Distance(transform.position, collision.transform.position) < tooClose) Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
