using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private float _maxSliderValue;
    private float _changeStep = 0.5f;

    private Coroutine _coroutine;

    private void Awake()
    {
        _maxSliderValue = _player.MaxHealthValue;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float healthChangingValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Change(healthChangingValue));
    }

    private IEnumerator Change(float currentValue)
    {
        float healthPercent = currentValue / _maxSliderValue;

        while (_slider.value != healthPercent)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, healthPercent, _changeStep * Time.deltaTime);
            yield return null;
        }
    }
}