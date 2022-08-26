using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private float _maxValue = 100f;
    private float _currentValue;
    private float _changeStep = 0.5f;

    private float _heal = 10f;
    private float _appliedDamage = -10f;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _currentValue/_maxValue, _changeStep * Time.deltaTime);
    }

    public void Heal()
    {
        if (_currentValue < _maxValue)
            _currentValue += _heal;
    }

    public void ApplyDamage()
    {
        if (_currentValue > 0)
            _currentValue += _appliedDamage;
    }
}
