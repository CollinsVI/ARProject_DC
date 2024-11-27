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
    [Header("Coin Object")]
    private GameObject coinPrefab; // Ensure this is assigned in the Inspector.

    [SerializeField]
    private float spawnInterval = 2f;

    private List<ARPlane> detectedPlanes = new List<ARPlane>();
    private bool canSpawnCoins = false;

    void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();

        // Check for null prefab at runtime
        if (coinPrefab == null)
        {
            Debug.LogError("Coin prefab is not assigned!");
            enabled = false;
            return;
        }

        // Subscribe to plane events
        aRPlaneManager.planesChanged += OnPlanesChanged;

        // Start spawning coins coroutine
        StartCoroutine(SpawnCoins());
    }

    void OnDestroy()
    {
        // Unsubscribe from plane events to avoid memory leaks
        aRPlaneManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        detectedPlanes.Clear();

        foreach (var plane in aRPlaneManager.trackables)
        {
            // Check for valid plane extents
            if (plane.extents.x > Mathf.Epsilon && plane.extents.y > Mathf.Epsilon)
            {
                detectedPlanes.Add(plane);
            }
        }

        // Update spawn condition based on detected planes
        canSpawnCoins = detectedPlanes.Count > 0;
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            if (canSpawnCoins && detectedPlanes.Count > 0)
            {
                // Select a random plane to spawn the coin
                ARPlane randomPlane = detectedPlanes[Random.Range(0, detectedPlanes.Count)];

                // Calculate a random position on the plane
                Vector3 spawnPosition = GetRandomPointOnPlane(randomPlane);

                // Instantiate coin and parent it to the plane to keep it anchored
                GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
                coin.transform.SetParent(randomPlane.transform);
            }

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomPointOnPlane(ARPlane plane)
    {
        // Get plane center and extents in local space
        Vector3 planeCenter = plane.center;
        Vector2 planeExtents = plane.extents;

        // Generate random local coordinates within the plane bounds
        float randomX = Random.Range(-planeExtents.x / 2, planeExtents.x / 2);
        float randomZ = Random.Range(-planeExtents.y / 2, planeExtents.y / 2);

        // Convert local coordinates to world coordinates
        return plane.transform.TransformPoint(new Vector3(randomX, 0, randomZ));
    }

    void Update()
    {
        // Debugging purpose: Print number of detected planes
        if (canSpawnCoins)
        {
            Debug.Log($"Detected {detectedPlanes.Count} planes available for spawning.");
        }
    }
}
