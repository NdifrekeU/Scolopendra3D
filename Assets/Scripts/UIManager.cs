using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text scoreText;
    public Text livesText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateLives(int lives)
    {
        livesText.text = $"Lives: {lives}";
    }
}
