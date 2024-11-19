using UnityEngine;

[RequireComponent(typeof(HealthView))]
public abstract class HealthBar : MonoBehaviour
{
    public abstract void DisplayHealth(int currentHealth, int maxHealth);

    protected float GetHealthValueForSlider(int currentHealth, int maxHealth)
    {
        return (float)currentHealth / maxHealth;
    }
}
