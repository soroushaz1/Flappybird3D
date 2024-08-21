using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float flapForce = 5f;  // The upward force applied when flapping
    public float gravityScale = 10f;  // Adjusts the strength of gravity on the bird
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  // Turn off the default gravity and handle it manually
    }

    void Update()
    {
        // Apply gravity manually
        rb.velocity += Vector3.down * gravityScale * Time.deltaTime;

        // Flap when space is pressed or mouse/tap is detected
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Flap();
        }
    }

    void Flap()
    {
        // Apply an upward force to make the bird fly upwards
        rb.velocity = Vector3.up * flapForce;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            // Game Over logic
            Debug.Log("Game Over");
            Time.timeScale = 0;  // Stop the game
        }
    }
}
