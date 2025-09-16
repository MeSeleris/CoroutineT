using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private const int _CommandGetPressMouseButton = 0;

    public event UnityAction Toggle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_CommandGetPressMouseButton))
        {
            Toggle?.Invoke();
        }
    }
}
