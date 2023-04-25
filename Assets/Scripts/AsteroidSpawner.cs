using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] Transform viper;

    [Header("Timers")]
    [SerializeField] float timeToSpawn = 2f;
    [SerializeField] float timeBetweenSpawn = 2f;
    [SerializeField] int nbAsteroidEachSpawn = 5;


    [Header("Spawn Area")]

    [SerializeField] float spawnAreaRadius = 20f;
    [SerializeField] float spawnAreaDistance = 20f;

    [Header("Entities")]
    [SerializeField] GameObject[] asteroids;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Time.time >= timeToSpawn && gameManager.secondCount < gameManager.globalGameTime - 4) // 4 = time take for an asteroid to reach the camera
        {
            generate();
            timeToSpawn = Time.time + timeBetweenSpawn;
        }
    }

    void generate()
    {

        for (int i = 0; i < nbAsteroidEachSpawn; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * spawnAreaRadius;
            int asteroidIndex = Random.Range(0, asteroids.Length);
            Instantiate(asteroids[asteroidIndex], new Vector3(randomPoint.x + viper.position.x, randomPoint.y + viper.position.y, spawnAreaDistance), Quaternion.identity);
        }
    }
}
