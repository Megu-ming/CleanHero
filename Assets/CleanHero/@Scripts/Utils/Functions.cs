using System;
using UnityEngine;

public static class Functions
{
    public static Action<int> OnTrashCollected;


    #region UI/Timer
    public static Action<int, int> OnTimeChanged; // 분, 초 전달
    public static Action OnTimeOver;

    #endregion
}
