using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_MainScene : MonoBehaviour
{
    public static UI_MainScene Instance;

    [SerializeField]
    Slider slider;
    [SerializeField]
    TextMeshProUGUI timerText;

    private void Start()
    {
        Instance = this;
    }

    void OnEnable()
    {
        GameTimer.OnTimeChanged += UpdateTimer;
        GameTimer.OnTimeOver += ShowTimeOver;
    }

    void OnDisable()
    {
        GameTimer.OnTimeChanged -= UpdateTimer;
        GameTimer.OnTimeOver -= ShowTimeOver;
    }

    private void Update()
    {
        if (GameTimer.Instance != null)
            GameTimer.Instance.UpdateTimer();
    }

    public void SetCleanProgressRatio(float value)
    {
        slider.value = value;
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
