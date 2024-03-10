using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerKeyboardPoller))]

public class PlayerDirectionSetter : MonoBehaviour
{
    private PlayerKeyboardPoller _playerKeycoardController;
    private Coroutine _setDirection;
    private Vector3 _currentDirection;

    public Vector3 CurrentDirection => _currentDirection;

    public void StartSetDirection()
    {
        if (_setDirection == null)
        {
            _setDirection = StartCoroutine(SetDirection());
        }
    }

    public void StopSetDirection()
    {
        if (_setDirection != null)
        {
            StopCoroutine(_setDirection);
            _setDirection = null;
        }
    }

    private void Awake()
    {
        _playerKeycoardController = GetComponent<PlayerKeyboardPoller>();

        StartSetDirection();
    }

    private IEnumerator SetDirection()
    {
        while (true)
        {
            if (_playerKeycoardController.IsMoveUp & _playerKeycoardController.IsMoveRight)
            {
                _currentDirection = StaticPlayerDirectionValue.UpAndRightDirection;
            }
            else if (_playerKeycoardController.IsMoveUp & _playerKeycoardController.IsMoveLeft)
            {
                _currentDirection = StaticPlayerDirectionValue.UpAndLeftDirection;
            }
            else if (_playerKeycoardController.IsMoveDown & _playerKeycoardController.IsMoveRight)
            {
                _currentDirection = StaticPlayerDirectionValue.DownAndRightDirection;
            }
            else if (_playerKeycoardController.IsMoveDown & _playerKeycoardController.IsMoveLeft)
            {
                _currentDirection = StaticPlayerDirectionValue.DownAndLeftDirection; 
            }
            else if(_playerKeycoardController.IsMoveUp)
            {
                _currentDirection = StaticPlayerDirectionValue.UpDirection;
            }
            else if (_playerKeycoardController.IsMoveDown)
            {
                _currentDirection = StaticPlayerDirectionValue.DownDirection;
            }
            else if (_playerKeycoardController.IsMoveRight)
            {
                _currentDirection = StaticPlayerDirectionValue.RightDirection;
            }
            else if (_playerKeycoardController.IsMoveLeft)
            {
                _currentDirection = StaticPlayerDirectionValue.LeftDirection;
            }
            else
            {
                _currentDirection = StaticPlayerDirectionValue.Null;
            }            

            yield return null;
        }
    }
}