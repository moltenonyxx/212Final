using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] int pointsforEnemyKill = 50;
    float xSpeed;
    Rigidbody2D bulletRb;

    PlayerMovement player;
    EnemyCounter enemyCounter;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        bulletRb.linearVelocity = transform.up * bulletSpeed;
        enemyCounter = FindFirstObjectByType<EnemyCounter>();
    }

    void Update()
    {
        bulletRb.linearVelocity = transform.up * bulletSpeed;
        bulletRb.transform.rotation = transform.rotation;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            FindFirstObjectByType<GameSession>().AddToScore(pointsforEnemyKill);
            enemyCounter.EnemyDestroyed();
            Destroy(other.gameObject);
            if (enemyCounter.enemiesAlive == 0)
            {
                Debug.Log("All enemies destroyed!");
            }
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
