using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerSpeedSetter))]
[RequireComponent(typeof(Animator))]

public class PlayerAnimatorController : MonoBehaviour
{
    private PlayerSpeedSetter _playerSpeedSetter;
    private Coroutine _setAnimatorParametrs;
    private Animator _animator;

    public void StartSetBoolAnimator()
    {
        if (_setAnimatorParametrs == null)
        {
            _setAnimatorParametrs = StartCoroutine(SetAnimatorParametrs());
        }
    }

    public void StopSetBoolAnimator()
    {
        if (_setAnimatorParametrs != null)
        {
            StopCoroutine(_setAnimatorParametrs);
            _setAnimatorParametrs = null;
        }
    }

    private void Awake()
    {
        _playerSpeedSetter = GetComponent<PlayerSpeedSetter>();
        _animator = GetComponent<Animator>();

        StartSetBoolAnimator();
    }

    private IEnumerator SetAnimatorParametrs()
    {
        while (true)
        {
            if (_playerSpeedSetter.CurrentSpeed > 0)
            {
                _animator.SetBool(StaticPlayerAnimatorValue.IsRun, true);
            }
            else
            {
                _animator.SetBool(StaticPlayerAnimatorValue.IsRun, false);
            }

            yield return null;
        }
    }
}