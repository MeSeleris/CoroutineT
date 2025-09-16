using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterUpdate += UpdateView;
    }

    private void OnDisable()
    {
        _counter.CounterUpdate += UpdateView;
    }

    public void UpdateView()
    {
        Debug.Log($"Counter: {_counter.Count}");
    }
}
