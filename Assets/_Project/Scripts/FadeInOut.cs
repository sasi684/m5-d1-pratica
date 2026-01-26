using System.Collections;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup _fadeInOut;
    [SerializeField] private float _fadeDuration = 2f;

    private bool _hasFaded = false;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_hasFaded)
            {
                StopCoroutine(FadeIn());
                StartCoroutine(FadeOut());
                _hasFaded = false;
            }
            else
            {
                StopCoroutine(FadeOut());
                StartCoroutine(FadeIn());
                _hasFaded = true;
            }
        }
    }

    IEnumerator FadeIn()
    {
        float timer = 0f;
        while (timer < _fadeDuration)
        {
            timer += Time.deltaTime;
            _fadeInOut.alpha = Mathf.Lerp(0f, 1f, timer / _fadeDuration);
            yield return null;
        }
        _fadeInOut.alpha = 1f;
    }

    IEnumerator FadeOut()
    {
        float timer = 0f;
        while (timer < _fadeDuration)
        {
            timer += Time.deltaTime;
            _fadeInOut.alpha = Mathf.Lerp(1f, 0f, timer / _fadeDuration);
            yield return null;
        }
        _fadeInOut.alpha = 0f;
    }

}
