using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private float _maxValue;
    private float _changeStep = 0.5f;

    private Coroutine _coroutine;

    private void Awake()
    {
        _maxValue = _player.MaxHealthValue;
    }

    private void OnEnable()
    {
        _player.ButtonClicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _player.ButtonClicked -= OnButtonClicked;
    }

    private void OnButtonClicked(float healthChangingValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Change(healthChangingValue));
    }

    private IEnumerator Change(float currentHealth)
    {
        while (_slider.value != (currentHealth / _maxValue))
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealth / _maxValue, _changeStep * Time.deltaTime);
            yield return null;
        }
    }
}