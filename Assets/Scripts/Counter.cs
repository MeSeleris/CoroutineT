using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _counter = 0f;
    private bool _isCountring = false;
    private Coroutine _conterCoroutine;

    private void Start()
    {
        Debug.Log($"Counter {_counter}");
    }

    private void Update()
    {
        CoroutineControler();
    }

    private void Stop()
    {
        _isCountring = false;
        if (_conterCoroutine != null)
        {
            StopCoroutine(_conterCoroutine);
            _conterCoroutine = null;
        }
    }

    private void CoroutineControler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCountring)
            {
                Stop();
            }
            else
            {
                _isCountring = true;
                _conterCoroutine = StartCoroutine(CountUp());
            }
        }
    }

    private IEnumerator CountUp()
    {
        while (true)
        {
            _counter++;
            Debug.Log($"Counter {_counter}");

            yield return new WaitForSeconds(0.5f);
        }
    }
} 