using System.Collections;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup _fadeInOut;
    [SerializeField] private float _fadeDuration = 2f;

    private bool _hasFaded = false;
    private Coroutine _fadeCoroutine;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_fadeCoroutine != null) StopCoroutine(_fadeCoroutine);

            float targetAlpha = _hasFaded ? 0f : 1f;
            _fadeCoroutine = StartCoroutine(Fade(targetAlpha));
            _hasFaded = !_hasFaded;
        }
    }

    IEnumerator Fade(float targetAlpha)
    {
        float timer = 0f;
        while (timer < _fadeDuration)
        {
            timer += Time.deltaTime;
            _fadeInOut.alpha = Mathf.Lerp(_fadeInOut.alpha, targetAlpha, timer / _fadeDuration);

            yield return null;
        }
        _fadeInOut.alpha = targetAlpha;
    }

}
