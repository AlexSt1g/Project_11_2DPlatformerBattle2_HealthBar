using System;

public interface ICollectable
{
    public event Action Collected;

    public void PickUp() { }
}
