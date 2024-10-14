using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Controller controller;
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerRigidbody;

    private Vector2 direction = Vector2.zero;
    [SerializeField, Range(1f, 10f)] float speed;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        controller.OnMoveEvent += Move;
    }

    void FixedUpdate()
    {
        ApplyMovement(direction);
    }

    private void Move(Vector2 vector)
    {
        direction = vector;
    }

    private void ApplyMovement(Vector2 vector)
    {
        vector = vector * speed;
        playerRigidbody.velocity = vector;
        playerSprite.flipX = (vector.x != 0) ? (vector.x < 0) : playerSprite.flipX;
    }

}
