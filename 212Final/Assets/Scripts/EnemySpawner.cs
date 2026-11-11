using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    WaveSetup currentWave;
    [SerializeField] bool isLooping;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] WaveSetup[] waveSetup;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WaveSetup wave in waveSetup)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate
                    (
                        currentWave.GetEnemyPrefab(i),
                        currentWave.GetStaringWaypoint().position,
                        Quaternion.identity, //tells it no rotation
                        transform
                    );
                    yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);


    }

    public WaveSetup GetCurrentWave()
    {
        return currentWave;
    }

}
