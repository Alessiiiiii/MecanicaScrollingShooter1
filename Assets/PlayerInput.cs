using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float force = 50f;
    private Rigidbody rb;
    private Vector2 input;

    [Header("Disparo")]
    public GameObject Bala; // Prefab de la bala
    public Transform Spawner; // Lugar desde donde se dispara
    public float velocidadBala = 20f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    public void OnDisparar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bala = Instantiate(Bala, Spawner.position, Spawner.rotation);
            Rigidbody rbBala = bala.GetComponent<Rigidbody>();
            rbBala.linearVelocity = Vector3.up * velocidadBala;
            Destroy(bala, 3f); // La bala se autodestruye tras 3 segundos


            Debug.Log("¡Disparo!");
        }
    }

    private void FixedUpdate()
    {
        Vector3 direccion = new Vector3(input.x, input.y, 0f); // Movimiento en X/Y
        rb.AddForce(direccion * force);
    }
}