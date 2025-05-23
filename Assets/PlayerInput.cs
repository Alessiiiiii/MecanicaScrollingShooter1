using UnityEngine;
using UnityEngine.InputSystem; // Necesario para el nuevo Input System

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 moveInput;

    void Update()
    {
        // Movimiento horizontal y vertical
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("El avion se mueve");// Captura el input del jugador
    }
}