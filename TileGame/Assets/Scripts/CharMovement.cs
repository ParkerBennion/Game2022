using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Material))]
public class CharMovement : MonoBehaviour
{
    private WaitForSeconds wfs1;
    Vector3 piviotPos;
    public bool awatingCommand;
    private bool activeUp, activeDown, activeLeft, activeRight;
    public float waitTime;
    private float rotationSpeed;


    public void Awake()
    {
        wfs1 = new WaitForSeconds(waitTime);
        
        piviotPos = new Vector3(0, 0, 0);
        piviotPos = new Vector3(0, 0, 0);
        
        awatingCommand = false;
        activeDown = false;
        activeLeft = false;
        activeRight = false;
        
        if (waitTime == 0)
        {
            waitTime = 1;
        }
        
    }

    private void Start()
    {
        rotationSpeed = 180/waitTime;
    }
    

    private void Update()
    {
        if (awatingCommand && activeUp)
        {
            transform.RotateAround(piviotPos + new Vector3(0,0,2.5f),Vector3.right,rotationSpeed*Time.deltaTime);
        }
        if (awatingCommand && activeDown)
        {
            transform.RotateAround(piviotPos + new Vector3(0,0,-2.5f),Vector3.left,rotationSpeed*Time.deltaTime);
        }
        if (awatingCommand && activeLeft)
        {
            transform.RotateAround(piviotPos + new Vector3(-2.5f,0,0),Vector3.forward,rotationSpeed*Time.deltaTime);
        }
        if (awatingCommand && activeRight)
        {
            transform.RotateAround(piviotPos + new Vector3(2.5f,0,0),Vector3.back,rotationSpeed*Time.deltaTime);
        }
        //movement of object




        if (Input.GetKeyDown(KeyCode.S))
        {
            TranslateDown();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TranslateUp();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            TranslateLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TranslateRight();
        }
        //keyboard controlls
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void TranslateUp()
    {
        if (!awatingCommand)
        {
            StartCoroutine(WaitUp());
            activeUp = true;
        }
    }
    public void TranslateDown()
    {
        if (!awatingCommand)
        {
            StartCoroutine(WaitDown());
            activeDown = true;
        }
    }
    public void TranslateLeft()
    {
        if (!awatingCommand)
        {
            StartCoroutine(WaitLeft());
            activeLeft = true;
        }
    }
    public void TranslateRight()
    {
        if (!awatingCommand)
        {
            StartCoroutine(WaitRight());
            activeRight = true;
        }
    }
    // called to run timed coroutines.

    IEnumerator WaitUp()
    {
        awatingCommand = true;
        yield return wfs1;
        awatingCommand = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        
        piviotPos += new Vector3(0, 0, 5f);
        transform.position = piviotPos;
        activeUp = false;
    }
    IEnumerator WaitDown()
    {
        awatingCommand = true;
        yield return wfs1;
        awatingCommand = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        
        piviotPos += new Vector3(0, 0, -5f);
        transform.position = piviotPos;
        activeDown = false;
    }
    IEnumerator WaitLeft()
    {
        awatingCommand = true;
        yield return wfs1;
        awatingCommand = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        
        piviotPos += new Vector3(-5, 0, 0);
        transform.position = piviotPos;
        activeLeft = false;
    }
    IEnumerator WaitRight()
    {
        awatingCommand = true;
        yield return wfs1;
        awatingCommand = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        
        piviotPos += new Vector3(5, 0, 0);
        transform.position = piviotPos;
        activeRight = false;
    }

    public void changeColor()
    {
        
    }

}
