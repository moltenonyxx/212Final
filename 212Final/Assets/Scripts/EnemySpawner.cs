using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    
    WaveSetup currentWave;
    public bool isLooping;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] WaveSetup[] waveSetup;
    [SerializeField] TMP_Text waveCompleteText;
    EnemyCounter enemyCounter;
    MainMenu loadNextScene;

    void Start()
    {
        loadNextScene = FindFirstObjectByType<MainMenu>();
        enemyCounter = FindFirstObjectByType<EnemyCounter>();
        StartCoroutine(SpawnEnemies());
        waveCompleteText.gameObject.SetActive(false);
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

    IEnumerator ShowWaveComplete()
    {
        waveCompleteText.gameObject.SetActive(true);

        for (int i = 0; i < 4; i++)
        {
            waveCompleteText.enabled = true;
            yield return new WaitForSeconds(0.5f);

            waveCompleteText.enabled = false;
            yield return new WaitForSeconds(0.5f);
        }

        waveCompleteText.gameObject.SetActive(false);
    }
}
