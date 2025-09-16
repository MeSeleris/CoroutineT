using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event UnityAction CounterUpdate;

    private float _delay = 0.5f;
    private Coroutine _coroutine;

    public int Count { get; private set; }

    private void OnEnable()
    {
        _inputReader.Toggle += ToggleCounter;
    }

    private void OnDisable()
    {
        _inputReader.Toggle -= ToggleCounter;
    }

    private void ToggleCounter()
    {
        if(_coroutine == null)
        {
            _coroutine = StartCoroutine(IncrementCounter());
        }
        else if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator IncrementCounter()
    {
        WaitForSeconds _wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            CounterUpdate?.Invoke();
            Count++;
            yield return _wait;
        }
    }
} 