using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 currentPosition;
    void Update()
    {
        currentPosition = CharMovement.realPositoin;
        transform.position = currentPosition;
    }
}
