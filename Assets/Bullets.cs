using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
   
    public float bulletSpeed = 50f;

    
    void Start()
    {

    }

  


     void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*bulletSpeed);
    }
}