﻿using System;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChangerHealth : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;

        private float _maxtHealth = 100;
        private float _currentHealth;

        public Action<float, float> OnHealthChanged;

        private void Awake()
        {
            ResetHealth();
        }

        public void AddHealth(float heal)
        {
            _currentHealth += heal;
            InvokeOnHealthChanged();
        }

        public void RemoveHealth(float damage)
        {
            _currentHealth -= damage;
            InvokeOnHealthChanged();
            _playerAnimator.PlayTakeDamage();
        }

        private void ResetHealth()
        {
            _currentHealth = _maxtHealth;
            InvokeOnHealthChanged();
        }

        private void InvokeOnHealthChanged() => OnHealthChanged?.Invoke(_currentHealth, _maxtHealth);
    }
}