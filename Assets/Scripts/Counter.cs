using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private ConsoleOut _consoleOut;
    private AdderCount _adderCount;

    private bool _isCounting = false;
    private Coroutine _counterCoroutine;

    private void Start()
    {
        _consoleOut = new ConsoleOut();
        _adderCount = new AdderCount(0.5f);

        Debug.Log($"Counter {_adderCount.CurrentNumber}");
    }

    private void Update()
    {
        GetPressButton();
    }

    private void Stop()
    {
        _isCounting = false;
        if (_counterCoroutine != null)
        {
            StopCoroutine(_counterCoroutine);
            _counterCoroutine = null;
        }
    }

    private void GetPressButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                Stop();
            }
            else
            {
                _isCounting = true;
                _counterCoroutine = StartCoroutine(CountUp());
            }
        }
    }

    private IEnumerator CountUp()
    {
        while (true)
        {
            _adderCount.Add();
            _consoleOut.Output(_adderCount.CurrentNumber);

            yield return new WaitForSeconds(0.5f);
        }
    }

    private class ConsoleOut
    {       
        public void Output(float number)
        {         
            Debug.Log($"Counter {number}");
        }
    }

    private class AdderCount
    {
        public AdderCount(float startNumber)
        {
            CurrentNumber = startNumber;
        }

        public float CurrentNumber { get; private set; }

        public void Add()
        {
            CurrentNumber += 1f;

        }
    }
} 