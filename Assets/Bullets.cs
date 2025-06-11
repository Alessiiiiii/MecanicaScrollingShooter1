using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int BulletDemage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigos"))
        {
            collision.gameObject.GetComponent<EnemyMovement>().ChangeHealth(BulletDemage);
        }
    }

}
