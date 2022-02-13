using UnityEngine;
using UnityEngine.Events;

public class Invoker : MonoBehaviour
{
    public UnityEvent startBehaviour;

    public void Start()
    {
        startBehaviour.Invoke();
    }
}