using System;
using UnityEngine;

public class TrashItem : MonoBehaviour
{
    public string trashName;
    public int scoreValue;

    public static Action<int> OnTrashCollected;

    public void Collected()
    {
        OnTrashCollected?.Invoke(scoreValue);
        Destroy(gameObject);
    }
}