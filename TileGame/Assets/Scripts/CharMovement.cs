using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Material))]
public class CharMovement : MonoBehaviour
{
    private WaitForSeconds wfs1;
    Vector3 piviotPos;
    public bool awatingCommand;
    public float waitTime;
    private float rotationSpeed;
    private int cordinateDirection = -1;
    public static Vector3 realPositoin;
    public SO_Variables gameSpeed;
    public GameObject LineToChange;
    public Vector3 LinesScale;
    public UnityEvent startMove;
    public UnityEvent endMove;


    public void Awake()
    {
        wfs1 = new WaitForSeconds(waitTime);
        
        piviotPos = new Vector3(0, 0, 0); 
        piviotPos = new Vector3(0, 0, 0);
        
        awatingCommand = false;

        if (waitTime == 0)
        {
            waitTime = 1;
        }
    }

    public void setWaitTime()
    {
        waitTime = gameSpeed.floatVar;
        wfs1 = new WaitForSeconds(waitTime);
        rotationSpeed = 180/gameSpeed.floatVar;
    }

    private void Start()
    {
        rotationSpeed = 180/waitTime;
        LinesScale = LineToChange.transform.localScale;
        LineToChange.transform.localScale = LinesScale;
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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            LinesScale += new Vector3(0,0,10);
            LineToChange.transform.localScale += LinesScale;
        }

    }
    
    public void inputS()
    {
        if (!awatingCommand)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(0,0,-5));
            cordinateDirection = 1;
        }
        
    }
    public void inputW()
    {
        if (!awatingCommand)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(0,0,5));
            cordinateDirection = 0;
        }
        
    }
    public void inputA()
    {
        if (!awatingCommand)
        {
            startMove.Invoke();
            TranslateCube(new Vector3(-5,0,0));
            cordinateDirection = 2;
        }
        
    }
    public void inputD()
    {
        if (!awatingCommand)
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