using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void Start()
    {
        if(_counter != null)
        {
            _counter.onCounterUpdate.AddListener(UpdateView);
        }
    }

    private void UpdateView(int value)
    {
        Debug.Log($"Counter: {value}");
    }
}
