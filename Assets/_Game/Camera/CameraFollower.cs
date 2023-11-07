using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target; // Цель, за которой следит камера
    public float smoothSpeed = 0.125f; // Плавность следования
    public Vector3 offset; // Отступ от цели

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Настройте угол обзора камеры, если это необходимо
            // transform.LookAt(target.position);
        }
    }
}