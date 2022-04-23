using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Material))]
public class CharMovement : MonoBehaviour
{
    private WaitForSeconds wfs1;
    Vector3 piviotPos;
    public bool awatingCommand;
    private float rotationSpeed;
    private int cordinateDirection = -1;
    public static Vector3 realPositoin;
    public SO_Variables gameSpeed;
    public UnityEvent startMove;
    public UnityEvent endMove;
    public SO_Variables waitTimeSO;
    public SO_BoolArray canMoveBool;
    


    public void Awake()
    {
        wfs1 = new WaitForSeconds(waitTimeSO.floatVar);
        
        piviotPos = new Vector3(0, 0, 0); 
        piviotPos = new Vector3(0, 0, 0);
        
        awatingCommand = false;

        if (waitTimeSO.floatVar == 0)
        {
            waitTimeSO.floatVar = 1;
        }
    }

    public void setWaitTime()
    {
        waitTimeSO.floatVar = gameSpeed.floatVar;
        wfs1 = new WaitForSeconds(waitTimeSO.floatVar);
        rotationSpeed = 180/gameSpeed.floatVar;
    }

    private void Start()
    {
        rotationSpeed = 180/waitTimeSO.floatVar;
        
    }


    private void Update()
    {
        if (awatingCommand && cordinateDirection == 0)
        {
            transform.RotateAround(piviotPos + new Vector3(0,0,2.5f),Vector3.right,rotationSpeed*Time.deltaTime);
        }
        if (awatingCommand && cordinateDirection == 1)
        {
            transform.RotateAround(piviotPos + new Vector3(0,0,-2.5f),Vector3.left,rotationSpeed*Time.deltaTime);
        }
        if (awatingCommand && cordinateDirection == 2)
        {
            transform.RotateAround(piviotPos + new Vector3(-2.5f,0,0),Vector3.forward,rotationSpeed*Time.deltaTime);
        }
        if (awatingCommand && cordinateDirection == 3)
        {
            transform.RotateAround(piviotPos + new Vector3(2.5f,0,0),Vector3.back,rotationSpeed*Time.deltaTime);
        }
        //movement of object




        if (Input.GetKey(KeyCode.S)&& !awatingCommand)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(0,0,-5));
            cordinateDirection = 1;
        }
        if (Input.GetKey(KeyCode.W)&& !awatingCommand)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(0,0,5));
            cordinateDirection = 0;
        }
        if (Input.GetKey(KeyCode.A)&& !awatingCommand)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(-5,0,0));
            cordinateDirection = 2;
        }
        if (Input.GetKey(KeyCode.D)&& !awatingCommand)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(5,0,0));
            cordinateDirection = 3;
        }
        //keyboard controlls

        realPositoin = transform.position;


        

    }
    
    public void inputS()
    {
        if (!awatingCommand && !canMoveBool.BM)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(0,0,-5));
            cordinateDirection = 1;
        }
        
    }
    public void inputW()
    {
        if (!awatingCommand && !canMoveBool.TM)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(0,0,5));
            cordinateDirection = 0;
        }
        
    }
    public void inputA()
    {
        if (!awatingCommand && !canMoveBool.ML)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(-5,0,0));
            cordinateDirection = 2;
        }
        
    }
    public void inputD()
    {
        if (!awatingCommand && !canMoveBool.MR)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(5,0,0));
            cordinateDirection = 3;
        }
        
    }
    


    public void TranslateCube(Vector3 dirVector)
    {
        if (!awatingCommand)
        {
            StartCoroutine(WaitForVector(dirVector));
        }
    }
    
    IEnumerator WaitForVector(Vector3 dirVector)
    {
        awatingCommand = true;
        yield return wfs1;
        awatingCommand = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        
        piviotPos += dirVector;
        transform.position = piviotPos;
        
        endMove.Invoke();
    }
    

}

// [Serializable]
// public struct PassableVector
// {
//     public float x, y, z;
// }