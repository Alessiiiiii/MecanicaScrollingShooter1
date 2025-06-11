using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;  // Velocidad configurable en el Inspector
    public float range = 5f;  // Distancia m�xima de movimiento lateral
    public int health = 10; // Variable de vida del enemigo

    private Vector3 startPosition;
    private int direction = 1; // Direcci�n inicial (1 = derecha, -1 = izquierda)

    void Start()
    {
        startPosition = transform.position; // Guarda la posici�n inicial
    }

    void Update()
    {
        // Mueve al enemigo lateralmente
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // Cambia la direcci�n si alcanza el l�mite
        if (Mathf.Abs(transform.position.x - startPosition.x) >= range)
        {
            direction *= -1; // Invierte la direcci�n
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