using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]
public class ARPlacement : MonoBehaviour
{
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;

    [SerializeField]
    private GameObject coinPrefab; 

    [SerializeField]
    private float spawnInterval = 2f; 

    private List<ARPlane> detectedPlanes = new List<ARPlane>();
    private bool canSpawnCoins = false;

    void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();

        
        StartCoroutine(SpawnCoins());
    }

    void Update()
    {
        
        UpdateDetectedPlanes();
        Debug.Log("Yo we detecting");

    }

    private void UpdateDetectedPlanes()
    {
        detectedPlanes.Clear();

        foreach (var plane in aRPlaneManager.trackables)
        {
            if (plane.extents.x > 0 && plane.extents.y > 0) 
            {

                detectedPlanes.Add(plane);

            }
        }

        //Only spawn if plane is detected.
        canSpawnCoins = detectedPlanes.Count > 0;
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            if (canSpawnCoins)
            {
                
                // Select a random plane to spawn the coin
                ARPlane randomPlane = detectedPlanes[Random.Range(0, detectedPlanes.Count)];

                // Random Pos
                Vector3 spawnPosition = GetRandomPointOnPlane(randomPlane);

                // Instantiate st Random Pos
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            }

            
            yield return new WaitForSeconds(spawnInterval);

            Debug.Log("Yoooo we spawnin");
        }

        
    }

    private Vector3 GetRandomPointOnPlane(ARPlane plane)
    {
        
        Vector3 planeCenter = plane.center;
        Vector2 planeExtents = plane.extents;

        
        float randomX = Random.Range(-planeExtents.x / 2, planeExtents.x / 2);
        float randomZ = Random.Range(-planeExtents.y / 2, planeExtents.y / 2);

        
        return plane.transform.TransformPoint(new Vector3(randomX, 0, randomZ));

    }
}
