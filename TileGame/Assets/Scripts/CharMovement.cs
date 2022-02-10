using System.Collections;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    private WaitForSeconds wfs1;
    Vector3 worldPos;
    public bool awatingCommand;
    public bool activeUp, activeDown, activeLeft, activeRight;

    public void Awake()
    {
        wfs1 = new WaitForSeconds(.5f);
        worldPos = new Vector3(0, 0, 0);
        awatingCommand = false;
        activeDown = false;
        activeLeft = false;
        activeRight = false;
    }

    private void Update()
    {
        if (awatingCommand && activeUp)
        {
            transform.RotateAround(worldPos + new Vector3(0,0,2.5f),Vector3.right,360*Time.deltaTime);
        }
        if (awatingCommand && activeDown)
        {
            transform.RotateAround(worldPos + new Vector3(0,0,-2.5f),Vector3.left,360*Time.deltaTime);
        }
        if (awatingCommand && activeLeft)
        {
            transform.RotateAround(worldPos + new Vector3(-2.5f,0,0),Vector3.forward,360*Time.deltaTime);
        }
        if (awatingCommand && activeRight)
        {
            transform.RotateAround(worldPos + new Vector3(2.5f,0,0),Vector3.back,360*Time.deltaTime);
        }




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
    }

    public void TranslateUp()
    {
        
        // transform.RotateAround(worldPos + new Vector3(0,0,-2.5f),Vector3.right,180);
        
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

    public IEnumerator WaitUp()
    {
        awatingCommand = true;
        yield return wfs1;
        awatingCommand = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        worldPos += new Vector3(0, 0, 5f);
        activeUp = false;
    }
    public IEnumerator WaitDown()
    {
        awatingCommand = true;
        yield return wfs1;
        awatingCommand = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        worldPos += new Vector3(0, 0, -5f);
        activeDown = false;
    }
    public IEnumerator WaitLeft()
    {
        awatingCommand = true;
        yield return wfs1;
        awatingCommand = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        worldPos += new Vector3(-5, 0, 0);
        activeLeft = false;
    }
    public IEnumerator WaitRight()
    {
        awatingCommand = true;
        yield return wfs1;
        awatingCommand = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        worldPos += new Vector3(5, 0, 0);
        activeRight = false;
    }

}
