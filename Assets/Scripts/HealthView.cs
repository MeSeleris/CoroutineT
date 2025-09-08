using System.Collections;
using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript2 : MonoBehaviour
{
    [SerializeField] private float _smothDecreaseDuration = 0.5f;
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Color _damageHealthColor;
    [SerializeField] private AnimationCurve _colorBehaviour;
    [SerializeField] private Animator _heartAnimation;
    [SerializeField] private AnimationClip _heathPulseAnimation;

    private Color _originalHealthColor;
    private Coroutine _coroutine; 

    private void Start()
    {
        _originalHealthColor = _healthText.color;
        _healthText.text = _health.MaxHealth.ToString();
    }

    private void OnEnable()
    {
        _health.Changed += TakeDamage;
    }

    private void OnDisable()
    {
        _health.Changed -= TakeDamage;
    }

    private void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void TakeDamage(float currentHealth)
    {
        _heartAnimation.Play(_heathPulseAnimation.name);
        _coroutine = StartCoroutine(DecreaseHealthSmoothly(currentHealth));
    }

    private IEnumerator DecreaseHealthSmoothly(float target)
    {
        float elapsedTime = 0f;
        float previousValue = float.Parse(_healthText.text);

        while (elapsedTime < _smothDecreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / _smothDecreaseDuration;
            float intermediateValue = Mathf.Lerp(previousValue, target, normalizedPosition);
            _healthText.text = intermediateValue.ToString();

            _healthText.color = Color.Lerp(_originalHealthColor, _damageHealthColor, _colorBehaviour.Evaluate(normalizedPosition));

            yield return null;
        }
    }
}
