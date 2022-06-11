using UnityEngine;

public class obstacleScript : MonoBehaviour
{

    public ObstaclesGenerator ObstaclesGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * ObstaclesGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextline"))
        {
            ObstaclesGenerator.GenerateNextObstacleWithGap();
        }

        if (collision.gameObject.CompareTag("finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
