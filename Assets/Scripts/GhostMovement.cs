using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 initialDirection;
    public float speedMultiplier = 1.0f;

    public Rigidbody2D rgb;
    public LayerMask wall;
    public Vector2 direction;
    public Vector2 nextDirection ;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (this.nextDirection != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }
    }

    public void ResetState()
    {
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector2 position = rgb.position;
        rgb.MovePosition(position + direction * speed * speedMultiplier * Time.fixedDeltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
        if (!Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else
        {
            this.nextDirection = direction;
        }
    }
    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, wall);
        return hit.collider != null;
    }
}
