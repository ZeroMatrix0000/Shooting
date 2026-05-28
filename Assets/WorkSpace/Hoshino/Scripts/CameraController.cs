using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float MoveSpeed;
    [SerializeField] private Vector2 MoveDirection = new Vector2( 1, 0 );

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ê≥ãKâª
        MoveDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        // à íuÇïœçX
        transform.position += new Vector3(MoveDirection.x, MoveDirection.y, 0) * MoveSpeed * Time.deltaTime;
    }
}
