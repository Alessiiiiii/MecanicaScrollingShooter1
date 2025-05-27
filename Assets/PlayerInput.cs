using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float force = 50f;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector2 input;
     public GameObject balaPrefab;  // Prefab de la bala
    public Transform puntoDisparo; // Lugar desde donde se dispara
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
        dispararAction.Enable();
    }

    private void OnDisable()
    {
        dispararAction.Disable();
    }


    private void Update()
    {
       input= playerInput.actions["Move"].ReadValue<Vector2>();
        Debug.Log(input);
        if (dispararAction.triggered)
        {
            Disparar();
        }
        void Disparar()
        {
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
            bala.GetComponent<Rigidbody>().linearVelocity = Vector3.up * velocidadBala; // Movimiento hacia arriba en Y
            Debug.Log("�Disparo en Y!");
        }





    }

    public void FixedUpdate()
    {
        rb.AddForce(new Vector2(input.x,input.y)*force);
    }
  

}