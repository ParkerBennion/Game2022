using UnityEngine;
[CreateAssetMenu]
public class SO_Locator : ScriptableObject
{
    public Vector3 location;
    public Vector3 currentCord;

    public void SetPosition(Transform cord)
    {
        location = cord.position;
        //Debug.Log(location);
    }

    public void GoToPosition(Transform cord)
    {
        cord.position = location;
    }
    
    
    public void AddVector(Transform vecto)
    {
        currentCord = vecto.position;
    }

    public void printer()
    {
        //Debug.Log(location + " location");
        //Debug.Log(currentCord + " currentCord");
    }
}
