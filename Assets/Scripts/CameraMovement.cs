using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // ���� Ÿ�� (ĳ����)
    public Vector3 offset;   // ī�޶�� Ÿ�� ���� ������
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ�
    public float fixedZPosition = -15f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Ÿ���� ��ġ�� �������� ���� ��ǥ ��ġ ���
            Vector3 desiredPosition = target.position + offset;

            // Z ��ǥ ����
            desiredPosition.z = fixedZPosition;

            // �ε巯�� �̵��� ���� ī�޶� ��ġ ���
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // ī�޶� ��ġ ����
            transform.position = smoothedPosition;

            // ī�޶� Ÿ���� �ٶ󺸵��� ���� (�ɼ�)
            transform.LookAt(target);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget; // Ÿ�� ����
    }
}
