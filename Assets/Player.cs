using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private float _heal = 10f;
    private float _appliedDamage = -10f;

    public float HealthMaxValue { get; private set; } = 100f;
    public float HealthCurrentValue { get; private set; }

    public event Action<float> ButtonClicked;

    private void Awake()
    {
        HealthCurrentValue = HealthMaxValue;
    }

    public void Heal()
    {
        ButtonClicked?.Invoke(_heal);
    }

    public void ApplyDamage()
    {
        ButtonClicked?.Invoke(_appliedDamage);
    }
}
