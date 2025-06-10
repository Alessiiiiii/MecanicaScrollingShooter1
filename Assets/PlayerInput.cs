using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float force = 50f;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector2 input;
    public GameObject Bala; // Prefab de la bala
    public Transform Spawner; // Lugar desde donde se dispara
    public float velocidadBala = 20f;
    public InputAction dispararAction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        dispararAction.performed += ctx => Disparar(); // Detecta el disparo correctamente
        dispararAction.Enable();
    }

    private void OnDisable()
    {
        dispararAction.Disable();
    }

    private void Update()
    {
        input = playerInput.actions["Move"].ReadValue<Vector2>(); // Leer input del movimiento
    }

    void Disparar()
    {
        GameObject bala = Instantiate(Bala, Spawner.position, Quaternion.identity);
        bala.GetComponent<Rigidbody>().linearVelocity = Vector3.up * velocidadBala; // Movimiento de la bala
        Debug.Log("¡Disparo realizado!");
    }

    public void FixedUpdate()
    {
        rb.AddForce(new Vector2(input.x, input.y) * force); // Movimiento del jugador
    }
}