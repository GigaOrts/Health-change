using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _incomingHealing = 10f;
    private float _incomingDamage = -10f;

    public float MaxHealthValue { get; private set; } = 100f;
    public float MinHealthValue { get; private set; } = 0f;
    public float CurrentHealthValue { get; private set; }

    public event Action<float> ButtonClicked;

    private void Awake()
    {
        CurrentHealthValue = MaxHealthValue;
    }

    public void Heal() => ButtonClicked?.Invoke(CalculateCurrentHealth(_incomingHealing));

    public void ApplyDamage() => ButtonClicked?.Invoke(CalculateCurrentHealth(_incomingDamage));

    private float CalculateCurrentHealth(float healthChangingValue)
    {
        CurrentHealthValue += healthChangingValue;
        return Mathf.Clamp(CurrentHealthValue, MinHealthValue, MaxHealthValue);
    }
}