using UnityEngine;

[CreateAssetMenu(fileName = "WaveSetup 0", menuName = "New WaveSetup")]
public class WaveSetup : ScriptableObject
{
    [SerializeField] Transform pathPrefabs;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float enemyMoveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float enemySpawnVarience = 0f;
    [SerializeField] float minSpawnTime = 0.2f;


    
    

    public Transform GetStaringWaypoint()
    {
        return pathPrefabs.GetChild(0).transform;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;

    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public Transform[] GetWaypoints()
    {
        Transform[] waypoints = new Transform[pathPrefabs.childCount];
        for (int i = 0; i < pathPrefabs.childCount; i++)
        {
            waypoints[i] = pathPrefabs.GetChild(i);
        }

        return waypoints;
    }

    public float GetRandomEnemySpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - enemySpawnVarience,
            timeBetweenEnemySpawns + enemySpawnVarience);

        spawnTime = Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
        return spawnTime;
    }
}
