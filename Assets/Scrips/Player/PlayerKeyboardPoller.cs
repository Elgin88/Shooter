using System.Collections;
using UnityEngine;

public class PlayerKeyboardPoller : MonoBehaviour
{
    private Coroutine _checkPressedButtons;
    private bool _isMoveUp = false;
    private bool _isMoveDown = false;
    private bool _isMoveRight = false;
    private bool _isMoveLeft = false;

    public bool IsMoveUp => _isMoveUp;
    public bool IsMoveDown => _isMoveDown;
    public bool IsMoveRight => _isMoveRight;
    public bool IsMoveLeft => _isMoveLeft;

    private void Awake()
    {
        StartCheckButtonKey();
    }

    private IEnumerator CheckPressedButtons()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.W))
                _isMoveUp = true;
            else
                _isMoveUp = false;

            if (Input.GetKey(KeyCode.S))
                _isMoveDown = true;
            else
                _isMoveDown = false;

            if (Input.GetKey(KeyCode.D))
                _isMoveRight = true;
            else
                _isMoveRight = false;

            if (Input.GetKey(KeyCode.A))
                _isMoveLeft = true;
            else
                _isMoveLeft = false;

            yield return null;
        }
    }

    private void StartCheckButtonKey()
    {
        if (_checkPressedButtons == null)
        {
            _checkPressedButtons = StartCoroutine(CheckPressedButtons());
        }        
    }

    private void StopCheckButtonKey()
    {
        StopCoroutine(_checkPressedButtons);
        _checkPressedButtons = null;
    }
}