using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public void SetHealth(int Health)
    {
        slider.value = Health;
    }
    public void MaxHealth(int Health)
    {
        slider.maxValue = Health;
        slider.value = Health;
    }
}
