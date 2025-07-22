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
                Debug.Log("���� ������: " + trash.name);
                PlayerStealth ps = gameObject.GetComponent<PlayerStealth>();
                ps.isPickingTrash = true;
                Destroy(trash.gameObject); // ���߿� �κ��丮�� �߰�
                break;
            }
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            PlayerStealth ps = gameObject.GetComponent<PlayerStealth>();
            ps.isPickingTrash = false;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
