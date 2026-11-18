using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    WaveSetup currentWave;
    public bool isLooping;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] WaveSetup[] waveSetup;
    EnemyCounter enemyCounter;


    void Start()
    {

        enemyCounter = FindFirstObjectByType<EnemyCounter>();
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
                        Quaternion.identity,
                        transform
                    );
                    enemyCounter.EnemySpawned();
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
