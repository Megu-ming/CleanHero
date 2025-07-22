using UnityEngine;

public class Logo : MonoBehaviour
{
    public float floatStrength = 0.5f;  // 위아래로 이동할 범위
    public float floatSpeed = 2f;       // 속도

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.localPosition = startPos + new Vector3(0f, offset, 0f);
    }
}
