using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private float _maxValue;
    private float _minValue;
    private float _currentValue;
    private float _changeStep = 0.5f;

    private Coroutine _coroutine;

    private void Awake()
    {
        _maxValue = _player.HealthMaxValue;
        _minValue = 0f;
        _currentValue = _maxValue;
    }

    private void OnEnable()
    {
        _player.ButtonClicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _player.ButtonClicked -= OnButtonClicked;
    }

    private IEnumerator Change(float healthChangingValue)
    {
        _currentValue += healthChangingValue;
        _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);

        while (_slider.value != (_currentValue / _maxValue))
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _currentValue / _maxValue, _changeStep * Time.deltaTime);
            yield return null;
        }
    }

    private void OnButtonClicked(float healthChangingValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Change(healthChangingValue));
    }
}
