﻿using System.Collections;
using UnityEngine;

namespace Scripts.Logic
{
    public class CurtainShower : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private const float _stepChangeAlpha = 0.03f;
        private const float _delay = 0.03f;
        private WaitForSeconds _delayWFS = new WaitForSeconds(_delay);

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }

        public void Hide() => StartCoroutine(FadeIn());

        public IEnumerator FadeIn()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= _stepChangeAlpha;
                yield return _delayWFS;
            }

            gameObject.SetActive(false);
        }
    }
}