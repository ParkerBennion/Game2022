using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInstanceScript : MonoBehaviour
{
    public GridLayout gridhere;
    public Grid otherGrid;
    public GridBrushBase gridBrush;
    public GameObject instanceObj;
    private Vector3 cubeSpawn;
    private Vector3 cubeSpawn2;

    private void Start()
    {
        cubeSpawn = otherGrid.LocalToCell(new Vector3(3,0,0));
        cubeSpawn2 = otherGrid.LocalToCell(new Vector3(-3,0,0));
        var setRotation = transform.rotation;
        Instantiate(instanceObj, cubeSpawn, setRotation);
        Instantiate(instanceObj, cubeSpawn2, setRotation);
        
    }
    
}
