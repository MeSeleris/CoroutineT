using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class Counter : MonoBehaviour
{
    public IntEvent onCounterUpdate;

    private int count = 0;

    [SerializeField] private InputReader _inputReader;

    private Coroutine _coroutine;

    private bool _isRunning = false;

    private void Start()
    {
        if(_inputReader != null)
        {
            _inputReader.onToggle.AddListener(ToggleCounter);
        }
    }

    private void ToggleCounter(bool shouldStart)
    {
        if(shouldStart == true && _isRunning == false)
        {
            _isRunning = true;
            _coroutine = StartCoroutine(IncrementCounter());
        }
        else if (shouldStart == false && _isRunning == true)
        {
            _isRunning= false;
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator IncrementCounter()
    {
        while(true)
        {
            onCounterUpdate.Invoke(count);
            count++;
            yield return new WaitForSeconds(0.5f);
        }
    }
} 