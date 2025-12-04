using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public bool isSeen = false;
    private float speed = 1.0f;
    public int health = 3;
    GameObject enemy;
    public Rigidbody2D Rigidbody2D;
    private float healthTimer = 0.0f;
    private bool stopMove;
    private GameObject manager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        manager = GameObject.FindGameObjectWithTag("Manager");

    }

    // Update is called once per frame
    void Update()
    {
        stopMove = !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D);
        healthTimer -= Time.deltaTime;
        if (enemy.GetComponent<enemyScript>().hasLoS && healthTimer <= 0 && Rigidbody2D.linearVelocity.magnitude > 0.25f)
        {
            health -= 1;
            healthTimer = 2.0f;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Rigidbody2D.AddForce(new Vector2(0, 1) * speed);
        }        
        if (Input.GetKey(KeyCode.A))
        {
            Rigidbody2D.AddForce(new Vector2(-1, 0) * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {         
            Rigidbody2D.AddForce(new Vector2(0, -1) * speed);
        }        
        if (Input.GetKey(KeyCode.D))
        {           
            Rigidbody2D.AddForce(new Vector2(1, 0) * speed);
        }
        if (stopMove && Rigidbody2D.linearVelocity.magnitude < 0.5f)
        {
            Rigidbody2D.linearVelocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //Fungerar ej, ändra till collision och inte trigger?
    {
        if (collision.name == "Goal Collider")
        {
            manager.GetComponent<managerScript>().finish = true;
        }
    }
}
