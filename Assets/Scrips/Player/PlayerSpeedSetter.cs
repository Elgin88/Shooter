using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerKeyboardPoller))]

public class PlayerSpeedSetter : MonoBehaviour
{
    private PlayerKeyboardPoller _playerKeyboardController;
    private Coroutine _setSpeed;
    private float _speedOfRun = 5.5f;
    private float _currentSpeed;

    public float CurrentSpeed => _currentSpeed;

    private void Awake()
    {
        _playerKeyboardController = GetComponent<PlayerKeyboardPoller>();

        StartSetSpeed();
    }

    private IEnumerator SetSpeed()
    {
        while (true)
        {
            if (_playerKeyboardController.IsMoveUp || _playerKeyboardController.IsMoveDown || _playerKeyboardController.IsMoveRight || _playerKeyboardController.IsMoveLeft)
            {
                _currentSpeed = _speedOfRun;
            }
            else
            {
                _currentSpeed = 0;
            }

            yield return null;
        }
    }

    private void StartSetSpeed()
    {
        if (_setSpeed == null)
        {
            _setSpeed = StartCoroutine(SetSpeed());
        }
    }

    private void StopSetSpeed()
    {
        if (_setSpeed != null)
        {
            StopCoroutine(_setSpeed);
            _setSpeed = null;
        }
    }
}