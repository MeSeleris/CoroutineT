using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CounterView _counterView;

    public event UnityAction CounterUpdate;  

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
        while(true)
        {
            CounterUpdate?.Invoke();
            Count++;
            yield return new WaitForSeconds(0.5f);
        }
    }
} 