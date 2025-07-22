using UnityEngine;

public class CitizenController : MonoBehaviour
{
    public float viewRadius = 5f;
    public float viewAngle = 90f; // 시야 각도
    public LayerMask targetLayer;

    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetLayer);
        foreach (Collider2D hit in hits)
        {
            PlayerStealth ps = hit.GetComponent<PlayerStealth>();
            if (ps != null && ps.isPickingTrash && IsInView(hit.transform))
            {
                Debug.Log("들켰다! 시민이 정면에서 감지함!");
                // TODO: 경고 UI, 패널티 등
            }
        }
    }

    bool IsInView(Transform target)
    {
        Vector2 dirToTarget = (target.position - transform.position).normalized;
        float angleToTarget = Vector2.Angle(transform.right, dirToTarget); // 오른쪽이 정면
        return angleToTarget < viewAngle / 2f;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.25f);
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        // 시야 각도 시각화
        Vector3 rightDir = Quaternion.Euler(0, 0, viewAngle / 2) * transform.right;
        Vector3 leftDir = Quaternion.Euler(0, 0, -viewAngle / 2) * transform.right;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + rightDir * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + leftDir * viewRadius);
    }
}
