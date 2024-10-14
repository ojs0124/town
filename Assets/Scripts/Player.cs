using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Field
    Vector2 moveVector;
    Vector2 lookVector;

    [SerializeField, Range(1f, 10f)] float speed;

    SpriteRenderer playerSprite;
    Rigidbody2D playerRigidbody;
    Collider2D playerCollider;
    Animator playerAnimator;
    Camera _camera;

    void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 nextVector = moveVector * speed * Time.fixedDeltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + nextVector);
    }

    void LateUpdate()
    {
        playerAnimator.SetBool("isWalk", moveVector.magnitude > 0 ? true : false);
        playerSprite.flipX = (moveVector.x != 0) ? (moveVector.x < 0) : playerSprite.flipX;
    }

    void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();
    }
    
    void OnLook(InputValue value)
    {
        lookVector = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
    }
}
