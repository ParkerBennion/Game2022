using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public SO_Variables addPoints;
    public void Destroy()
    {
        addPoints.intVar++;
        Destroy(gameObject);
    }
}
