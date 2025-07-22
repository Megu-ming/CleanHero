using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // 에디터에서 종료
#else
        Application.Quit();  // 빌드된 게임에서 종료
#endif
    }
}
