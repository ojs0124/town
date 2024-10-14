using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;


public class PlayerAnimationController : AnimationController
{
    private static readonly int isWalk = Animator.StringToHash("isWalk");

    private readonly float magnitudeThreshold = 0.5f;


    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(isWalk, obj.magnitude > magnitudeThreshold);
    }
}
