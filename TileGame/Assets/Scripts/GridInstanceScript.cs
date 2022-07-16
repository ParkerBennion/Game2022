using System.Collections;
using UnityEngine;

public class GridInstanceScript : MonoBehaviour
{
    public GridLayout gridhere;
    public GameObject instanceObj;
    private Vector3 cubeSpawn;
    public int currentCube=0, finalCube=1;
    private WaitForSeconds awaitCubePlace;


    private void Start()
    {
        var setRotation = transform.rotation;

        cubeSpawn = gridhere.CellToLocal(new Vector3Int(30, 1, 1));
        //Instantiate(Instantiate(instanceObj, cubeSpawn, setRotation));
    }


    public void generateLevel()
    {
        StartCoroutine(GenerateNextLevel());
    }
    
    IEnumerator GenerateNextLevel()
    {
        var setRotation = new Quaternion(0,0,0,0);
        awaitCubePlace = new WaitForSeconds(.1f);
        cubeSpawn = gridhere.CellToWorld(new Vector3Int(-10, 0, 10));

        while (currentCube < finalCube)
        {
            
            Instantiate(instanceObj, cubeSpawn, setRotation);
            currentCube += 1;
            cubeSpawn += new Vector3(5, 0, 0);
            yield return awaitCubePlace;
            
        }

        currentCube = 0;
        cubeSpawn = gridhere.CellToWorld(new Vector3Int(-10, 0, 15));

        while (currentCube < finalCube)
        {
            Instantiate(instanceObj, cubeSpawn, setRotation);
            currentCube += 1;
            cubeSpawn += new Vector3(5, 0, 0);
            yield return awaitCubePlace;
        }
        
        currentCube = 0;
        cubeSpawn = gridhere.CellToWorld(new Vector3Int(-10, 0, 20));
        while (currentCube < finalCube)
            
        {
            Instantiate(instanceObj, cubeSpawn, setRotation);
            currentCube += 1;
            cubeSpawn += new Vector3(5, 0, 0);
            yield return awaitCubePlace;
        }

        currentCube = 0;
        //gridHolderObj.SetActive(false);
        
        
        
        yield break;
        
        
    }
    //cubeSpawn = gridhere.CellToLocal(new Vector3Int(30, 1, 1));
}
