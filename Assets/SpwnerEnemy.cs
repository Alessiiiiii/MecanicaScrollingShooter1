using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemigos; // Array de enemigos
    public GameObject bossEnemy; // Jefe final
    public float spawnInterval = 3f; // Tiempo inicial entre spawns
    public float minSpawnInterval = 1f; // Tiempo mínimo entre spawns
    public float spawnDecreaseRate = 0.1f; // Reducción del tiempo de spawn
    private int enemigosKilled = 0; // Contador de enemigos eliminados

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemigosKilled >= 6) // Si se han eliminado 6 enemigos, aparece el jefe
        {
            Instantiate(bossEnemy, transform.position, Quaternion.identity);
            CancelInvoke("SpawnEnemy"); // Detiene el spawn de enemigos normales
            return;
        }

        // Generar un enemigo aleatorio
        int index = Random.Range(0, enemigos.Length);
        Instantiate(enemigos[index], transform.position, Quaternion.identity);

        // Reducir el tiempo de spawn progresivamente
        spawnInterval = Mathf.Max(spawnInterval - spawnDecreaseRate, minSpawnInterval);
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    public void EnemyDefeated()
    {
        enemigosKilled++;
    }
}