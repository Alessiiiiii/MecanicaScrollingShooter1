using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float range = 30f;
    private Vector3 startPosition;
    private int direction = 1;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector3.right * direction * speed * Time.fixedDeltaTime);

        if (Mathf.Abs(rb.position.x - startPosition.x) >= range)
        {
            direction *= -1; // Cambia la dirección
        }
    }
}