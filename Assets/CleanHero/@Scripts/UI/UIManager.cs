using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI timerText;

    private void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        Functions.OnTimeChanged += UpdateTimer;
        Functions.OnTimeOver += ShowTimeOver;
    }

    void OnDisable()
    {
        Functions.OnTimeChanged -= UpdateTimer;
        Functions.OnTimeOver -= ShowTimeOver;
    }

    void UpdateTimer(int min, int sec)
    {
        timerText.text = $"{min:D2}:{sec:D2}";
    }

    void ShowTimeOver()
    {
        timerText.text = "00:00";
        Debug.Log("게임 시간 종료!");
        // TODO: 게임 오버 처리
    }
}
