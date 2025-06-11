using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject Base;  // Prefab del piso
    public Transform spawnPoint;  // Lugar donde se generará el piso
    public float spawnInterval = 10f;  // Cada cuánto tiempo se genera un nuevo piso

    void Start()
    {
        InvokeRepeating("Base", 0f, spawnInterval);
    }

    void SpawnFloor()
    {
        GameObject newFloor = Instantiate(Base, spawnPoint.position, Quaternion.identity);
        Destroy(newFloor, 10f); // Se destruye después de 10 segundos
    }
}