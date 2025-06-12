using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public float range = 10f;
    public int health = 10;

    private Vector3 startPosition;
    private int direction = 1;

    public EnemySpawner spawner; //  Esto lo agregamos

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - startPosition.x) >= range)
        {
            direction *= -1;
        }
    }

    public void ChangeHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            if (spawner != null)
            {
                spawner.EnemyDefeated();
            }
            Destroy(gameObject);
        }
    }
}