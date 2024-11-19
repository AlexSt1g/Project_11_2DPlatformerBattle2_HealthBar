using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public event Action Collected;

    public void PickUp()
    {
        Collected?.Invoke();
    }
}
