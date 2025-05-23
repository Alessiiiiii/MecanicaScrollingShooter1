using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SeriaLizeField]
    GameObject[] Base;
    public Transform spawnPoint;
    void Start()
    {
        SpawnBase();
       InvokeReapiting("SpawnBase", 0, 1f);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnBase()
    {
        int randomIndex=Random.Range(0,blocks.Length);
        GameObjet Base= Instantiate(Base[randomIndex],spawnPoint.position,Quaternon.identity);
        Base.transform.SetParent(transform);
    }
}
