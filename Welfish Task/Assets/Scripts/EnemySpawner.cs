using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Renderer planeRenderer;

    float planeBoundsMaxX;
    float planeBoundsMinX;
    float planeBoundsMaxZ;
    float planeBoundsMinZ;

    float spawnPointX;
    float spawnPointZ;
    Vector3 spawnPoint;

    float spawnDelay = 2f;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject spawnVfx;
    GameObject vfxInstantiate;

    private void Awake()
    {
        planeRenderer = GetComponent<Renderer>();
        planeBoundsMaxX = planeRenderer.bounds.max.x;
        planeBoundsMinX = planeRenderer.bounds.min.x;
        planeBoundsMaxZ = planeRenderer.bounds.max.z;
        planeBoundsMinZ = planeRenderer.bounds.min.z;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) {
            spawnPointX = Random.Range(planeBoundsMinX, planeBoundsMaxX);
            spawnPointZ = Random.Range(planeBoundsMinZ, planeBoundsMaxZ);
            spawnPoint = new Vector3(spawnPointX, 0f, spawnPointZ);
            //Debug.Log("x: " + spawnPointX);
            //Debug.Log("z: " + spawnPointZ);
            vfxInstantiate = Instantiate(spawnVfx, spawnPoint + Vector3.up, Quaternion.identity) as GameObject;
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            if (spawnDelay > 1f) {
                spawnDelay -= Time.deltaTime;
            }
            Debug.Log(spawnDelay);
            yield return new WaitForSeconds(spawnDelay);
            Destroy(vfxInstantiate);
        }
    }


}
