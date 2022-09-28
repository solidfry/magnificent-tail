using System;
using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;


namespace UI
{
    public class UIFade : MonoBehaviour
    {
        public float waitTime = 2f;
        public float duration = 2f;
        public float startValue = 1f;
        public float targetValue = 0;
        private CanvasGroup canvasGroup;
        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = this.AddComponent<CanvasGroup>();
                canvasGroup.alpha = startValue;
            }
        }

        private void Update()
        {
            StartCoroutine(Fade());
        }

        IEnumerator Fade()
        {
            yield return new WaitForSeconds(waitTime);
            canvasGroup.DOFade(targetValue, duration);
        }
    }
}