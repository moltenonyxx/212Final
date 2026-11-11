using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] int pointsforEnemyKill = 50;
    float xSpeed;
    Rigidbody2D bulletRb;

    PlayerMovement player;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        bulletRb.linearVelocity = transform.up * bulletSpeed;
        Debug.Log("Bullet velocity: " + bulletRb.linearVelocity);
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
            Destroy(other.gameObject); 
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 1f);
    }
}
