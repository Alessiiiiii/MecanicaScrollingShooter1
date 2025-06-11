using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;  // Velocidad configurable en el Inspector
    public float range = 5f;  // Distancia máxima de movimiento lateral
    public int health = 10; // Variable de vida del enemigo

    private Vector3 startPosition;
    private int direction = 1; // Dirección inicial (1 = derecha, -1 = izquierda)

    void Start()
    {
        startPosition = transform.position; // Guarda la posición inicial
    }

    void Update()
    {
        // Mueve al enemigo lateralmente
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // Cambia la dirección si alcanza el límite
        if (Mathf.Abs(transform.position.x - startPosition.x) >= range)
        {
            direction *= -1; // Invierte la dirección
        }

    }
    public void ChangeHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}