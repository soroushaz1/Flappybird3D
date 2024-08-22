using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; // Reference to the pipe prefab
    public float spawnRate = 2f; // Time between spawns
    public float gapHeight = 13f; // The gap between the top and bottom pipes
    public Transform bird; // Reference to the bird

    private float timer = 0f;
    private bool hasScored = false; // To track if the score has already been added

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipes();
            timer = 0f;
            hasScored = false; // Reset score tracking for the new pipes
        }

        CheckBirdPosition();
    }

    void SpawnPipes()
    {
        // Spawn the bottom pipe
        float randomY = Random.Range(-1.5f, 1.5f);
        Vector3 spawnPosition = new Vector3(10f, randomY - 5f, 0f);
        GameObject bottomPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

        // Spawn the top pipe
        Vector3 topPipePosition = new Vector3(spawnPosition.x, spawnPosition.y + gapHeight, spawnPosition.z);
        GameObject topPipe = Instantiate(pipePrefab, topPipePosition, Quaternion.identity);

        // Flip the top pipe on the Y-axis to mirror it
        bottomPipe.transform.localScale = new Vector3(1, -1, 1);
    }

    void CheckBirdPosition()
    {
        // Get the current position of the pipes (they should all have the same x position)
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        foreach (GameObject pipe in pipes)
        {
            float pipeXPosition = pipe.transform.position.x;
            float birdXPosition = bird.position.x;

            // If the bird passes the pipe's x position and is between the pipes
            if (!hasScored && birdXPosition > pipeXPosition)
            {
                float pipeYPosition = pipe.transform.position.y;
                float birdYPosition = bird.position.y;

                if (birdYPosition > pipeYPosition && birdYPosition < pipeYPosition + gapHeight)
                {
                    ScoreManager.instance.AddScore(1);
                    hasScored = true; // Prevent double scoring for the same pipes
                }
            }
        }
    }
}
