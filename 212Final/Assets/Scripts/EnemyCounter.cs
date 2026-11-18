using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public int enemiesSpawned = 0;
    public int enemiesAlive = 0;
    [SerializeField] TMP_Text waveCompleteText;
    EnemySpawner enemySpawner;
    MainMenu mainMenu;

    void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        mainMenu = FindFirstObjectByType<MainMenu>();
        
    }
    void Update()
    {
        EndLevelCheck();
    }
    public void EnemySpawned()
    {
        enemiesSpawned++;
        enemiesAlive++;
    }

    public void EnemyDestroyed()
    {
        enemiesAlive--;

        if (enemiesAlive < 0)
        {
            enemiesAlive = 0;
        }
    }

    public void EndLevelCheck()
    {
        if(enemySpawner.isLooping = false || enemiesAlive == 0)
        {
            StartCoroutine(ShowWaveComplete());
        }
    }

    IEnumerator ShowWaveComplete()
    {
        waveCompleteText.gameObject.SetActive(true);

        for (int i = 0; i < 2; i++)
        {
            waveCompleteText.enabled = true;
            yield return new WaitForSeconds(1f);

            waveCompleteText.enabled = false;
            yield return new WaitForSeconds(1f);
        }
        waveCompleteText.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}