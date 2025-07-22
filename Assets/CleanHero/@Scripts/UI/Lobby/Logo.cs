using UnityEngine;

public class Logo : MonoBehaviour
{
    public float floatStrength = 0.5f;  // ���Ʒ��� �̵��� ����
    public float floatSpeed = 2f;       // �ӵ�

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
