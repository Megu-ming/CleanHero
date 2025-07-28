using UnityEngine;

public class CitizenController : MonoBehaviour
{
    public Transform[] patrolPoints;     // 순찰 경로 지점
    public float speed = 1f;
    public float waitTime = 3f;

    private int currentIndex = 0;
    private float waitTimer = 0f;

    void Update()
    {
        
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currentIndex];
        Vector2 dir = (target.position - transform.position).normalized;

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // 시민 회전 방향 설정 (시야 방향과 일치하게 하려면 중요!)
        if (dir.x != 0)
            transform.right = new Vector3(Mathf.Sign(dir.x), 0, 0);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                currentIndex = (currentIndex + 1) % patrolPoints.Length;
                waitTimer = 0f;
            }
        }
    }
}
