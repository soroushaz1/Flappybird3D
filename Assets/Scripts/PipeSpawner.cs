using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; // Reference to the pipe prefab
    public float spawnRate = 2f; // Time between spawns
    public float gapHeight = 13f; // The gap between the top and bottom pipes

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipes();
            timer = 0f;
        }
    }

    void SpawnPipes()
    {
        // Spawn the bottom pipe
        float randomY = Random.Range(-1f, 1f);
        Vector3 spawnPosition = new Vector3(10f, randomY - 5f, 0f);
        GameObject bottomPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

        // Spawn the top pipe and mirror it on the y-axis
        Vector3 topPipePosition = new Vector3(spawnPosition.x, spawnPosition.y + gapHeight, spawnPosition.z);
        GameObject topPipe = Instantiate(pipePrefab, topPipePosition, Quaternion.identity);

        // Flip the top pipe on the Y-axis to mirror it
        bottomPipe.transform.localScale = new Vector3(1, -1, 1);

        // Optionally, you can make the top pipe a child of the bottom pipe (this is not mandatory)
        // topPipe.transform.parent = bottomPipe.transform;
    }
}
