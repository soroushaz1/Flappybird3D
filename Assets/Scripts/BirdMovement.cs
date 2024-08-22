using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour
{
    public float flapForce = 5f;  // The upward force applied when flapping
    public float gravityScale = 10f;  // Adjusts the strength of gravity on the bird
    private Rigidbody rb;
    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  // Turn off the default gravity and handle it manually
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
            return;
        }

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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);  // Log the collision
        if (other.gameObject.tag == "Pipe" || other.gameObject.tag == "Ground")
        {
            StartCoroutine(RestartGameAfterDelay(1f));  // Restart after 1 second delay
        }
    }

    IEnumerator RestartGameAfterDelay(float delay)
    {
        Debug.Log("Game Over");
        isGameOver = true;
        yield return new WaitForSeconds(delay);  // Wait for 1 second
        RestartGame();
    }

    void RestartGame()
    {
        Time.timeScale = 1;  // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Restart the current scene
    }
}
