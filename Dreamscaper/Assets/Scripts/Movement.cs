using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveLimit = 30;
    public float MoveSpeed = 10;
    private Vector3 StartPosition;

    private void Start()
    {
        StartPosition = transform.position;
    }

    private void Update()
    {
        Vector3 MoveVector = StartPosition;
        MoveVector.y += MoveLimit * Mathf.Sin(Time.time * MoveSpeed);
        transform.position = MoveVector;
    }
}
