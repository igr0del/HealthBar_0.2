using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarConroller : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _easeHealthSlider;
    [SerializeField] private CharacterController _character;
    [SerializeField] private float _lerpSpeed = 0.05f;

    private void Start()
    {
        _character = GetComponent<CharacterController>();

        SetMaxHealth(_character.MaxHealth);
    }

    private void Update()
    {
        SetCorrectHealth(_character.CorrectHealth);
    }

    private void SetMaxHealth(float health)
    {
        _healthSlider.maxValue = health;
        _easeHealthSlider.maxValue = health;

        _healthSlider.value = health;
        _easeHealthSlider.value = health;
    }

    private void SetCorrectHealth(float health)
    {
        if (_character.CorrectHealth <= _healthSlider.value)
        {
            _healthSlider.value = health;
            _easeHealthSlider.value = Mathf.Lerp(_easeHealthSlider.value, health, _lerpSpeed);
        }
        else 
        {
            _easeHealthSlider.value = health;
            _healthSlider.value = Mathf.Lerp(_healthSlider.value, health, _lerpSpeed);
        }
    }
}
