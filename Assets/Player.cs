using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MaxHealthValue { get; private set; } = 100f;
    public float MinHealthValue { get; private set; } = 0f;
    public float CurrentHealthValue { get; private set; }

    public event Action<float> HealthChanged;

    private void Awake()
    {
        CurrentHealthValue = MaxHealthValue;
    }

    public void Heal(float heal) => HealthChanged?.Invoke(CalculateCurrentHealth(heal));

    public void ApplyDamage(float damage) => HealthChanged?.Invoke(CalculateCurrentHealth(damage));

    private float CalculateCurrentHealth(float healthChangingValue)
    {
        CurrentHealthValue += healthChangingValue;
        return CurrentHealthValue = Mathf.Clamp(CurrentHealthValue, MinHealthValue, MaxHealthValue);
    }
}