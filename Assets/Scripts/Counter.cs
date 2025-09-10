using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private InputReader _inputReader;

    private void Start()
    {
        _inputReader = new InputReader();

        Debug.Log($"Counter {_inputReader.CurrentNumber}");
    }

    private void Update()
    {
        _inputReader.GetPressButton();
    }

    private class InputReader :MonoBehaviour
    {
        CounterView _counterView = new CounterView();

        private bool _isCounting = false;
        private Coroutine _counterCoroutine;

        public float CurrentNumber {  get; private set; }

        public void GetPressButton()
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

        private void Stop()
        {
            _isCounting = false;
            if (_counterCoroutine != null)
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }
        }

        private IEnumerator CountUp()
        {
            while (true)
            {
                CurrentNumber += 1f;
                _counterView.Output(CurrentNumber);

                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private class CounterView
    {       
        public void Output(float number)
        {         
            Debug.Log($"Counter {number}");
        }
    }
} 