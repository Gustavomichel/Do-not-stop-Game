using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    public GameObject Obstacles;
    public GameObject AirObstacles;
    public GameObject airobstaclesgenerator;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    public int spawn_id;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = minSpeed;
        GenerateObstacles();
    }

    public void GenerateNextObstacleWithGap()
    {
        //Randomize obstacles
        float randomwait = Random.Range(0.001f, 0.002f);
        Invoke("GenerateObstacles", randomwait);

        //Sort obstacles
        int randowspawn = Random.Range(1, 4);

        if (randowspawn < 3)
        {
            spawn_id = 0;
            print("spwn 0");
        }
        else if (randowspawn >= 3)
        {
            spawn_id = 1;
            print("spwn 1");
        }
        print(randowspawn);

    }

    public void GenerateObstacles()
    {
        if(spawn_id == 0)
        {
           GameObject ObsIns = Instantiate(Obstacles, transform.position, transform.rotation);
            ObsIns.GetComponent<obstacleScript>().ObstaclesGenerator = this;
        }
        else if(spawn_id == 1)
        {
            GameObject ObsIns = Instantiate(AirObstacles, airobstaclesgenerator.transform.position, airobstaclesgenerator.transform.rotation);
            ObsIns.GetComponent<AirObstacleScript>().AirObstaclesGenerator = this;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed < maxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
        
    }
}
