using System;
using UnityEngine;

public static class Functions
{
    public static Action<int> OnTrashCollected;


    #region UI/Timer
    public static Action<int, int> OnTimeChanged; // ��, �� ����
    public static Action OnTimeOver;

    #endregion
}
