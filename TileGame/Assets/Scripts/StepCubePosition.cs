using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCubePosition : MonoBehaviour
{
    private Vector3 cubePos;

    private Vector3 addedPos;
    // Start is called before the first frame update
    void Start()
    {
        cubePos = new Vector3(0,-1,2.45f);
        addedPos = new Vector3(0, 0, 35f);
        deactivateCube();
        
    }

    private void deactivateCube()
    {
        gameObject.SetActive(false);
    }

    public void MoveCubePos()
    {
        cubePos += addedPos;
        transform.position = cubePos;
    }

}
