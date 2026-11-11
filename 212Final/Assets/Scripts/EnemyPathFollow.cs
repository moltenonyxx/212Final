using UnityEngine;

public class EnemyPathFollow : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveSetup waveSetup;
    Transform[] waypoints;
    int waypointIndex = 0;
    void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        waveSetup = enemySpawner.GetCurrentWave();
        waypoints = waveSetup.GetWaypoints();
        transform.position = waveSetup.GetStaringWaypoint().position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float moveDelta = waveSetup.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveDelta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
