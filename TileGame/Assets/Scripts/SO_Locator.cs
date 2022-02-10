using UnityEngine;

[CreateAssetMenu]

public class SO_Locator : ScriptableObject
{
    public Vector3 location;

    public void SetPosition(Transform cord)
    {
        location = cord.position;
        Debug.Log(location);
    }

    public void GoToPosition(Transform cord)
    {
        cord.position = location;
    }
}
