using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemigos;
    public GameObject bossEnemy;
    public float spawnInterval = 6f;
    public float minSpawnInterval = 3f;
    public float spawnDecreaseRate = 0.01f;
    public int enemigosKilled = 0; // Contador de enemigos eliminados
    public static EnemySpawner instance; // Permite acceso global al spawner

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 6f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemigosKilled >= 10) // Cambié a 10 eliminaciones para que aparezca el jefe
        {
            Instantiate(bossEnemy, transform.position, Quaternion.identity);
            CancelInvoke("SpawnEnemy");
            return;
        }

        int index = Random.Range(0, enemigos.Length);
        GameObject enemy = Instantiate(enemigos[index], transform.position, Quaternion.identity);

        // Asigna el script de referencia al enemigo (debe tener un script de muerte)
        enemy.GetComponent<EnemyMovement>().spawner = this;

        spawnInterval = Mathf.Max(spawnInterval - spawnDecreaseRate, minSpawnInterval);
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    public void EnemyDefeated()
    {
        enemigosKilled++;
    }
}