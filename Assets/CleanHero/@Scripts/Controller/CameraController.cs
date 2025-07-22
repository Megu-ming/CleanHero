using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPosition;

    private void LateUpdate()
    {
        if (target != null)
        {
            targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -10);//target.transform.position;
            transform.position = targetPosition;
        }
    }
}
