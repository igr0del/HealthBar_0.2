using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class Character : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _takeDamageButton;
    [SerializeField] private float _takeHealthButton;
    [SerializeField] private float _speedColorChange;

    private float _correctHealth;

    public float MaxHealth => _maxHealth;
    public float CorrectHealth => _correctHealth;

    private void Start()
    {
        _correctHealth = _maxHealth;

        SetValueDamageButton(_takeDamageButton);
        SetValueHealthButton(_takeHealthButton);
    }

    private void SetValueDamageButton(float damage)
    {
        _takeDamageButton = damage;
    }

    private void SetValueHealthButton(float health)
    {
        _takeHealthButton = health;
    }

    public void TakeDamage()
    {
        _spriteRenderer.DOColor(Color.white, 0).SetLoops(2, LoopType.Yoyo);

        if (_correctHealth > 0)
            _correctHealth -= _takeDamageButton;
        else
            _correctHealth = 0;

        _spriteRenderer.DOColor(Color.red, _speedColorChange).SetLoops(2, LoopType.Yoyo);
    }

    public void TakeHealth()
    {
        _spriteRenderer.DOColor(Color.white, 0).SetLoops(2, LoopType.Yoyo);

        if (_correctHealth < _maxHealth)
            _correctHealth += _takeHealthButton;
        else if (_correctHealth > _maxHealth)
            _correctHealth = _maxHealth;

        _spriteRenderer.DOColor(Color.green, _speedColorChange).SetLoops(2, LoopType.Yoyo);
    }
}
