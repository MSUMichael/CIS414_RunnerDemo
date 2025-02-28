//Michael A, 2/6/2024
//John Burke Lecture

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] powerUps; 
    [SerializeField]
    private int powerUpsPerType = 3;

    private Vector3 spawnAreaSize = new Vector3(30, 0, 30);
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPowerUps();
    }

    void SpawnPowerUps()
    {
        foreach(GameObject aPowerUps in powerUps)
        {
            for(int i = 0; i<powerUpsPerType; i++)
            {
                Vector3 randomPosition = GetRandomPosition();
                Instantiate(aPowerUps, randomPosition, Quaternion.identity);
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float y = 0;
        float z = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);

        return new Vector3(x, y, z);
    }

}
