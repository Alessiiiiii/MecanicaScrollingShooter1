using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public float speed;
    public float LimitPosY;
    public float resetPosY; // La posición a la que se reinicia

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Si llega al límite, lo enviamos a la posición inicial
        if (transform.position.y <= LimitPosY)
        {
            transform.position = new Vector3(transform.position.x, resetPosY, transform.position.z);
        }
    }
}