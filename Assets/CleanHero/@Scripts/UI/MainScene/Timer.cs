using UnityEngine;
using System;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    public float totalTime = 180f; // 3분
    private float currentTime;
    private bool isRunning = false;

    public static Action<int, int> OnTimeChanged; // 분, 초 전달
    public static Action OnTimeOver;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTime = totalTime;
        isRunning = true;
    }

    public void UpdateTimer()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f);

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        GameTimer.OnTimeChanged?.Invoke(minutes, seconds);

        if (currentTime <= 0f)
        {
            isRunning = false;
            GameTimer.OnTimeOver?.Invoke();
        }
    }
}
