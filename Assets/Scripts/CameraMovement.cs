using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // 따라갈 타겟 (캐릭터)
    public Vector3 offset;   // 카메라와 타겟 간의 오프셋
    public float smoothSpeed = 0.125f; // 카메라 이동 속도
    public float fixedZPosition = -15f;

    void LateUpdate()
    {
        if (target != null)
        {
            // 타겟의 위치에 오프셋을 더한 목표 위치 계산
            Vector3 desiredPosition = target.position + offset;

            // Z 좌표 고정
            desiredPosition.z = fixedZPosition;

            // 부드러운 이동을 위한 카메라 위치 계산
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // 카메라 위치 설정
            transform.position = smoothedPosition;

            // 카메라가 타겟을 바라보도록 설정 (옵션)
            transform.LookAt(target);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget; // 타겟 설정
    }
}
