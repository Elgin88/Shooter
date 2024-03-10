using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerDirectionSetter))]
[RequireComponent(typeof(PlayerSpeedSetter))]

public class PlayerMover : MonoBehaviour
{
    private PlayerDirectionSetter _playerDirectionSetter;
    private PlayerSpeedSetter _playerSpeedController;
    private Coroutine _move;

    public void StartMove()
    {
        if (_move == null)
        {
            _move = StartCoroutine(Move());
        }
    }

    public void StopMove()
    {
        if (_move != null)
        {
            StopCoroutine(_move);
            _move = null;
        }
    }

    private void Awake()
    {
        _playerDirectionSetter = GetComponent<PlayerDirectionSetter>();
        _playerSpeedController = GetComponent<PlayerSpeedSetter>();

        StartMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(_playerDirectionSetter.CurrentDirection * _playerSpeedController.CurrentSpeed * Time.deltaTime, Space.World);

            yield return null;
        }
    }
}