using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float dampTime = 0f;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private Vector3 velocity = Vector3.zero;
    private Vector3 camereoffset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        if (target)
        {
            Vector3 targetCamPos = target.position + offset + camereoffset;
            transform.position = Vector3.SmoothDamp(transform.position, targetCamPos, ref velocity, dampTime);
        }
    }
}
