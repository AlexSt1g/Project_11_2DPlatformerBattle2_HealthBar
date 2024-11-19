using UnityEngine;
using UnityEngine.UI;

public class NormalHealthBar : HealthBar
{
    [SerializeField] private Slider _healthBarSlider;
    
    public override void DisplayHealth(int currentHealth, int maxHealth)
    {
        _healthBarSlider.value = GetHealthValueForSlider(currentHealth, maxHealth);
    }
}
