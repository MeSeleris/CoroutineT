using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _counter = 0.5f;
    private bool _isCountring = false;
    private Coroutine _conterCoroutine;

    void Start()
    {
        Debug.Log($"Counter {_counter}");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (_isCountring)
            {
                 _isCountring = false;
                if(_conterCoroutine != null)
                {
                    StopCoroutine(_conterCoroutine);
                    _conterCoroutine = null;
                }
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
