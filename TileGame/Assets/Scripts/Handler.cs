using UnityEngine;
using UnityEngine.Events;

public class Handler : MonoBehaviour
{
    public SO_CallAction callactionObj;
    public UnityEvent handleEvent;
    public void Start()
    {
        callactionObj.callOut += Handle;
    }

    private void Handle()
    {
        handleEvent.Invoke();
    }
}