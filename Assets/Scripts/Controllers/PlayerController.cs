using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    private Camera _camera;


    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 lookPos = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(lookPos);
        lookPos = (worldPos - (Vector2)transform.position).normalized;

        if (lookPos.magnitude >= .9f)
        // Vector 값을 실수로 변환
        {
            CallLookEvent(lookPos);
        }
    }

    public void OnFire(InputValue value)
    {

    }

}
