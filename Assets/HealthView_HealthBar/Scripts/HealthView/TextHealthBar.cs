using TMPro;
using UnityEngine;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TextMeshProUGUI _healthText;    

    public override void DisplayHealth(int currentHealth, int maxHealth)
    {
        _healthText.text = $"Health: {currentHealth} / {maxHealth}";
    }
}
