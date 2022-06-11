using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirObstacleScript : MonoBehaviour
{
    public ObstaclesGenerator AirObstaclesGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * AirObstaclesGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextline"))
        {
            AirObstaclesGenerator.GenerateNextObstacleWithGap();
        }

        if (collision.gameObject.CompareTag("finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
