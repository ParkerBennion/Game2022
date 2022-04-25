using System;
using UnityEngine.Events;
using UnityEngine;

public class InvokeBasics : MonoBehaviour
{
    public UnityEvent startBehaviour, awakeBehaviour, triggerBehaviour, runBehaviour, disableBehaviour, destroyBehaviour, quitBehaviour;


    public void Awake()
    {
        awakeBehaviour.Invoke();
    }

    public void Start()
    {
        startBehaviour.Invoke();
    }

    public void Run()
    {
        runBehaviour.Invoke();
    }

    public void OnDisable()
    {
        disableBehaviour.Invoke();
    }

    public void OnDestroy()
    {
        destroyBehaviour.Invoke();
    }

    public void OnApplicationQuit()
    {
        quitBehaviour.Invoke();
    }

    public void OnTriggerEnter(Collider other)
    {
      
       if (other.gameObject.CompareTag("Player"))
        {
            triggerBehaviour.Invoke();
        }
    }
    
    
}