using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform RespawnPoint;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) other.gameObject.transform.position = RespawnPoint.position;
    }
}
