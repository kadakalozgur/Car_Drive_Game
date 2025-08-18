using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject emptyRoad;
    public GameObject roadsParent;

    public GameOverManager gameOverManager;

    public Transform mainCar;

    private List<GameObject> roads = new List<GameObject>();
    private List<GameObject> spawnedCars = new List<GameObject>();

    public List<GameObject> carPrefabs = new List<GameObject>();

    private float roadLength = 100f;
    private float roadWidth = 20f;
    private int laneCount = 3;
    private float carMax;

    void Start()
    {
        createRoad();

        carMax = mainCar.position.x;
    }

    void Awake()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {

        if(mainCar.position.x < carMax)
        {

            carMax = mainCar.position.x;

        }

        if (mainCar.position.x > carMax + 35f)
        {
            gameOverManager.Setup();
        }

        GameObject firstRoad = roads[0];

        for (int i = spawnedCars.Count - 1; i >= 0; i--)
        {

            if (spawnedCars[i].transform.position.x < mainCar.position.x - 300f)
            {

                Destroy(spawnedCars[i]);
                spawnedCars.RemoveAt(i);

            }
        }

        if (mainCar.position.x - firstRoad.transform.position.x < -100f)
        {
            roads.RemoveAt(0);

            for (int i = spawnedCars.Count - 1; i >= 0; i--)
            {

                if (spawnedCars[i].transform.position.x > mainCar.position.x + 30f)
                {
                    Destroy(spawnedCars[i]);
                    spawnedCars.RemoveAt(i);
                }

            }

            GameObject lastRoad = roads[roads.Count - 1];

            firstRoad.transform.position = lastRoad.transform.position + new Vector3(-100f, 0, 0);

            roads.Add(firstRoad);

            for (int j = 0; j < 2; j++)
            {

                spawnRandomCar(firstRoad);

            }
        }

        moveBotCars();
    }

    void createRoad()
    {

        roadsParent = new GameObject("Map");

        float startPosition = mainCar.position.x;

        for (int i = 0; i < 4; i++)
        {

            GameObject choseRoad;

            choseRoad = emptyRoad;

            GameObject newRoad = Instantiate(choseRoad, roadsParent.transform);

            newRoad.transform.position = new Vector3(startPosition - (i * 100), 0, 0);

            roads.Add(newRoad);

            //Spawn 8 car//

            for (int j = 0; j < 2; j++)
            {

                spawnRandomCar(newRoad);

            }
        }
    }

    void spawnRandomCar(GameObject road)
    {
        int randomPrefabIndex = Random.Range(0, carPrefabs.Count);
        int randomLane = Random.Range(0, laneCount);

        float laneWidth = roadWidth / laneCount;

        float randomXPosition;

        do
        {
            randomXPosition = Random.Range(-roadLength / 2f, roadLength / 2f);

        } while (road.transform.position.x + randomXPosition >= mainCar.position.x - 20f);


        float zPosition = -roadWidth / 2f + laneWidth / 2f + laneWidth * randomLane;

        if (randomLane == 0)
            zPosition += laneWidth * 0.1f;

        else if (randomLane == 2)
            zPosition -= laneWidth * 0.1f;

        Vector3 spawnPosition = road.transform.position + new Vector3(randomXPosition, 0.3f, zPosition);
        Quaternion rotation = Quaternion.Euler(0, 270, 0);

        GameObject newCar = Instantiate(carPrefabs[randomPrefabIndex], spawnPosition, rotation);

        spawnedCars.Add(newCar);
    }

    void moveBotCars()
    {

        for (int i = 0; i < spawnedCars.Count; i++)
        {
            if (spawnedCars[i] == null)
            {
                continue;
            }

            float speed = 20f;

            spawnedCars[i].transform.position += Vector3.left * speed * Time.deltaTime;
        }

    }
}
