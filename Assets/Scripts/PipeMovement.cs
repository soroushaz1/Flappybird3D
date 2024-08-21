using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            RespawnPipe();
        }
    }

    void RespawnPipe()
    {
        float randomY = Random.Range(-1f, 1f);
        transform.position = new Vector3(10f, randomY, transform.position.z);
    }
}
