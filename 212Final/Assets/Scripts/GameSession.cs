using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {
        
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
}
