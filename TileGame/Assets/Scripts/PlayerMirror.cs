using UnityEngine;

public class PlayerMirror : MonoBehaviour
{
    public GameObject player, self;

    private void Update()
    {
        self.transform.position = player.transform.position;
    }
}
