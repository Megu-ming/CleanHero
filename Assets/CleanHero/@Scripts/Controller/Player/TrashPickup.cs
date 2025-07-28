using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrashPickup : MonoBehaviour
{
    public float pickupRange = 1.5f;
    public LayerMask trashLayer;
    private PlayerStealth ps;

    private void Start()
    {
        ps = gameObject.GetComponent<PlayerStealth>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D trash = Physics2D.OverlapCircle(transform.position, pickupRange, trashLayer);

            TrashItem ti = trash.GetOrAddComponent<TrashItem>();
            Debug.Log("줍은 쓰레기: " + ti.name);
            ti.Collected();
            
            PlayerStealth ps = gameObject.GetComponent<PlayerStealth>();
            ps.isPickingTrash = true;

        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            ps.isPickingTrash = false;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
