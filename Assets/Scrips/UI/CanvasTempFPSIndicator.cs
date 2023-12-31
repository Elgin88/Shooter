using System.Collections;
using TMPro;
using UnityEngine;

namespace Shooter.UI
{
    public class CanvasTempFPSIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;

        private WaitForSeconds _delay = new WaitForSeconds(0.5f);

        private void Start()
        {
            StartCoroutine(ShowFPS());
        }

        private IEnumerator ShowFPS()
        {
            while (true)
            {
                _tmpText.text = Mathf.Round((1 / Time.deltaTime)).ToString();

                yield return _delay;
            }
        }
    }
}