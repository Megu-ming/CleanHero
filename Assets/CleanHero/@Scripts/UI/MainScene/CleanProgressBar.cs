using UnityEngine;
using UnityEngine.UI;

public class CleanProgressBar : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = 0.0f;
    }

    public void UpdatePB(float value)
    {
        slider.value = value;
    }
}
