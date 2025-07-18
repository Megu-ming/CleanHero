using UnityEngine;

public class CitizenController : MonoBehaviour
{
    public float viewRadius = 5f;
    public float viewAngle = 90f; // �þ� ����
    public LayerMask targetLayer;

    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetLayer);
        foreach (Collider2D hit in hits)
        {
            PlayerStealth ps = hit.GetComponent<PlayerStealth>();
            if (ps != null && ps.isPickingTrash && IsInView(hit.transform))
            {
                Debug.Log("���״�! �ù��� ���鿡�� ������!");
                // TODO: ��� UI, �г�Ƽ ��
            }
        }
    }

    bool IsInView(Transform target)
    {
        Vector2 dirToTarget = (target.position - transform.position).normalized;
        float angleToTarget = Vector2.Angle(transform.right, dirToTarget); // �������� ����
        return angleToTarget < viewAngle / 2f;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.25f);
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        // �þ� ���� �ð�ȭ
        Vector3 rightDir = Quaternion.Euler(0, 0, viewAngle / 2) * transform.right;
        Vector3 leftDir = Quaternion.Euler(0, 0, -viewAngle / 2) * transform.right;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + rightDir * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + leftDir * viewRadius);
    }
}
