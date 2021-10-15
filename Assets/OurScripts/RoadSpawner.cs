using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public GameObject grassTerrain;

    private Transform playerTransform;
    
    private float roadPos = 0.0f;
    private float roadLength = 10.0f;
    private int roadCtr = 20;
    
    private float terrainLength = 500.0f;
    private int terrainCtr = 2;
    private Vector3 moonPos = new Vector3(-500, -1, -500);
    
    
    private List<GameObject> activeRoads;
    private float safeZone = 10.0f;

    private int lastRoadIndex = 0;
    
    private List<GameObject> activeTerrain;
    private float safeZone2 = 500.0f;
    
    public GameObject apartments;

    private Vector3 apartmentPos = new Vector3(-25,-1,10);
    private float apartmentLength = 30.0f;
    private int apartmentCtr = 20;

    private List<GameObject> activeApartment;
    private float safeZone3 = 520.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        activeRoads = new List<GameObject>();
        activeTerrain = new List<GameObject>();
        activeApartment = new List<GameObject>();
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < roadCtr; i++)
        {
            if(i < 2)
                spawnRoad(0);
            else
            spawnRoad();
        }
            spawnGrass();
            spawnGrass();
            spawnGrass();
            
            spawnApartment();
            spawnApartment();
            spawnApartment();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (roadPos - roadCtr * roadLength))
        {
            spawnRoad();
            deleteRoad();
        }

        if (playerTransform.position.z - safeZone2 > moonPos.z - terrainCtr * terrainLength)
        {
            spawnGrass();
            deleteGrass();
        }
        
        if (playerTransform.position.z - safeZone3 > apartmentPos.z - apartmentCtr * apartmentLength)
        {
            spawnApartment();
            spawnApartment();
            deleteApartment();
        }
        
    }

    void spawnRoad(int prefabIndex = -1)
    {
        GameObject roadObj;
        for (int i = 0; i < 2; i++)
        {
            if (i == 1)
            {
                if (prefabIndex == -1)
                    roadObj = Instantiate(roadPrefabs[roadRandomIndex()]) as GameObject;
                else
                    roadObj = Instantiate(roadPrefabs[prefabIndex]) as GameObject;

                roadObj.transform.SetParent(transform);
                roadObj.transform.position = Vector3.forward * roadPos;
                roadPos += roadLength;
                activeRoads.Add(roadObj);
            }
            else
            {
                if (prefabIndex == -1)
                    roadObj = Instantiate(roadPrefabs[0]) as GameObject;
                else
                    roadObj = Instantiate(roadPrefabs[prefabIndex]) as GameObject;

                roadObj.transform.SetParent(transform);
                roadObj.transform.position = Vector3.forward * roadPos;
                roadPos += roadLength;
                activeRoads.Add(roadObj);
            }
                
        }
    }
    
    void deleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }

    int roadRandomIndex()
    {
        if (roadPrefabs.Length <= 1)
            return 0;

        int randomIndex = lastRoadIndex;
        while (randomIndex == lastRoadIndex)
        {
            randomIndex = Random.Range(0, roadPrefabs.Length);
        }

        lastRoadIndex = randomIndex;
        return randomIndex;
    }

    void spawnGrass()
    {
        GameObject grassObj;
        
        grassObj = Instantiate(grassTerrain, moonPos, Quaternion.identity) as GameObject;
        grassObj.transform.SetParent(transform);
        moonPos.z += terrainLength;
        activeTerrain.Add(grassObj);
    }
    
    void deleteGrass()
    {
        Destroy(activeTerrain[0]);
        activeTerrain.RemoveAt(0);
    }
    void spawnApartment()
    {
        GameObject apartment;

        apartment = Instantiate(apartments, apartmentPos, Quaternion.identity) as GameObject;
        apartment.transform.SetParent(transform);
        apartmentPos.z += apartmentLength;
        activeApartment.Add(apartment);
    }

    void deleteApartment()
    {
        Destroy(activeApartment[0]);
        activeApartment.RemoveAt(0);
    }
}