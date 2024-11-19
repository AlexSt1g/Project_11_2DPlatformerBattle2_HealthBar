using System;
using UnityEngine;

public class HealingPotion : MonoBehaviour, ICollectable
{   
    public event Action Collected;

    [field: SerializeField] public int HealingValue { get; private set; } = 50;

    public void PickUp()
    {
        Collected?.Invoke();
    }
}
