using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    internal void ChangeHealth(int bulletDemage)
    {
        throw new NotImplementedException();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bala")) // Verifica que sea una bala
        {
            ChangeHealth(-1); // Resta vida al enemigo
            Destroy(other.gameObject); // Destruye la bala al impactar
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
