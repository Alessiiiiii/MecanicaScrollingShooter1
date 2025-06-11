using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float force = 50f;
    private Rigidbody rb;
    private Vector2 input;

    [Header("Disparo")]
    public GameObject Bala; // Prefab de la bala
    public Transform Spawner; // Lugar desde donde se dispara
    public float velocidadBala = 20f;
    public int collectedItems;

    public TMPro.TextMeshProUGUI scoreText;
    
    public TMPro.TextMeshProUGUI WinText;
    public TMPro.TextMeshProUGUI GameOverText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        WinText.enabled = false;
        GameOverText.enabled = false;
    }
    void Start()
    {
       
        
        

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    public void OnDisparar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bala = Instantiate(Bala, Spawner.position, Spawner.rotation);
            Rigidbody rbBala = bala.GetComponent<Rigidbody>();
            rbBala.linearVelocity = Vector3.up * velocidadBala;
            Destroy(bala, 3f); // La bala se autodestruye tras 3 segundos


            Debug.Log("¡Disparo!");
        }
    }

    private void FixedUpdate()
    {
        Vector3 direccion = new Vector3(input.x, input.y, 0f); // Movimiento en X/Y
        rb.AddForce(direccion * force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Choque cotra : " + collision.gameObject.name);

       

        if (collision.gameObject.CompareTag("Enemigos"))
        {
            Debug.Log(GameOverText);
            SceneManager.LoadScene(1);
        }
        if (collision.gameObject.CompareTag("Goal"))
        {

            Destroy(collision.gameObject);
            Debug.Log(WinText);
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);

            collectedItems++;
            scoreText.text = collectedItems.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {


        Debug.Log("Trigger Enter:" + other.gameObject.name);
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            collectedItems++;
            scoreText.text = collectedItems.ToString();
        }
        
        if (other.gameObject.CompareTag("Goal"))
        {
            WinText.enabled = true;
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.CompareTag("Enemigos"))
        {
            GameOverText.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit:" + other.gameObject.name);


        
    }
    


}

    
