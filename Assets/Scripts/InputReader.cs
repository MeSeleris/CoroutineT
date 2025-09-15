using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BoolEvent : UnityEvent<bool> { }
public class InputReader : MonoBehaviour
{
    public BoolEvent onToggle;

    private bool _isRunning = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isRunning = !_isRunning;
            onToggle.Invoke(_isRunning);
        }
    }
}
