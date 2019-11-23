using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static Bootstrap instance;

    public GameObject CubePrefab;
    public GameObject Player;
    public GameObject VerticalBounds;
    public GameObject HorizontalBounds;
    public int gridX; 
    public int gridZ;
    public float SpacingOffset = 1f;
    private Vector3 gridOrigin = Vector3.zero;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
        Camera.main.transform.position = new Vector3(24, 46, 24);
        //EnemyBounds = new Vector3(gridX, 0, gridZ);
        Instantiate(Player, new Vector3(25, 1, 0), Quaternion.identity);
        Instantiate(VerticalBounds, new Vector3(-0.92f, 0.4f, 24.4f), Quaternion.identity);
        Instantiate(VerticalBounds, new Vector3(49.8f, 0.4f, 24.4f), Quaternion.identity);
        Instantiate(HorizontalBounds, new Vector3(25.1f, 0.4f, 49.9f), Quaternion.Euler(0,90,0));
        Instantiate(HorizontalBounds, new Vector3(25.1f, 0.4f, -0.9f), Quaternion.Euler(0, 90, 0));
    }

    private void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * SpacingOffset, 0, z * SpacingOffset) + gridOrigin;
                Spawn(spawnPosition, Quaternion.identity);
            }
        }
    }

    private void Spawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        GameObject clone = Instantiate(CubePrefab, positionToSpawn, rotationToSpawn);
    }    
}
