using UnityEngine;
using System;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    public float totalTime = 180f; // 3Ка
    private float currentTime;
    private bool isRunning = false;

    
    

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTime = totalTime;
        isRunning = true;
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f);

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        Functions.OnTimeChanged?.Invoke(minutes, seconds);

        if (currentTime <= 0f)
        {
            isRunning = false;
            Functions.OnTimeOver?.Invoke();
        }
    }
}
