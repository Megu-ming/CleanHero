using UnityEngine;
using UnityEngine.InputSystem;

public class TrashPickup : MonoBehaviour
{
    public float pickupRange = 1.5f;
    public LayerMask trashLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D[] nearbyTrash = Physics2D.OverlapCircleAll(transform.position, pickupRange, trashLayer);
            foreach (var trash in nearbyTrash)
            {
                Debug.Log("줍은 쓰레기: " + trash.name);
                Destroy(trash.gameObject); // 나중엔 인벤토리에 추가
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
