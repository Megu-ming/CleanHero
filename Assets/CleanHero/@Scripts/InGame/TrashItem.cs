using UnityEngine;

public class TrashItem : MonoBehaviour
{
    public string trashName;
    public int scoreValue;

    public void Collected()
    {
        Functions.OnTrashCollected?.Invoke(scoreValue);
        Destroy(gameObject);
    }
}