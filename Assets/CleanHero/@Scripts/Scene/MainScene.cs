using Unity.VisualScripting;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public static MainScene Instance;

    public int currentScore = 0;
    public const int maxScore = 100;

    private void Awake()
    {
        Instance = this;
        TrashItem.OnTrashCollected += HandleTrashCollected;
    }

    private void OnDestroy()
    {
        TrashItem.OnTrashCollected -= HandleTrashCollected;
    }

    private void HandleTrashCollected(int value)
    {
        currentScore += value;
        currentScore = Mathf.Min(currentScore, maxScore);
        Debug.Log($"현재 점수 : {currentScore}");
        
        UIManager.Instance.UpdateProgressBar((float)currentScore / maxScore);
    }
}
