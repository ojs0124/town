using System;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerLookPosition : MonoBehaviour
{
    private Controller controller;
    [SerializeField] private SpriteRenderer playerSprite;

    private void Awake()
    {
        controller = GetComponent<Controller>();
    }

    void Start()
    {
        controller.OnLookEvent += Look;
    }

    private void Look(Vector2 vector)
    {
        float rotZ = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        playerSprite.flipX = Mathf.Abs(rotZ) > 90f;
    }

}
