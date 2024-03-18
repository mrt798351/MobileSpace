using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        int score = PlayerPrefs.GetInt("Score" + SceneManager.GetActiveScene().name, 0);
        scoreText.text = "Score: " + score.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore" + "HighScore" + SceneManager.GetActiveScene().name, 0);
        highScoreText.text = "Highscore: " + highScore.ToString();
    }
}
