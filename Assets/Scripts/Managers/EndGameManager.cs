using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool isGameOver;
    public bool possibleWin;

    private PanelController panelController;
    private TextMeshProUGUI _scoreText;
    public PlayerStates player;
    private RewardedAd _rewardedAd;

    public int score;

    [HideInInspector]
    public string lvlUnlock = "LevelUnlock";
    private void Awake()
    {
        if (endManager == null)
        {
            endManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        _scoreText.text = "Score: " + score.ToString();
    }

    public void ResolveGame()
    {
        if (possibleWin == true && isGameOver == false)
        {
            WinGame();
        }
        else if (possibleWin == false && isGameOver == true)
        {
            // LoseGame();
            AdLoseGame();
        }
        else if (possibleWin == true && isGameOver == true)
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        player.canTakeDmg = false;
        ScoreSet();
        panelController.ActivateWin();
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel > PlayerPrefs.GetInt(lvlUnlock, 0))
        {
            PlayerPrefs.SetInt(lvlUnlock, nextLevel);
        }
    }
    
    public void LoseGame()
    {
        ScoreSet();
        panelController.ActivateLose();    
    }

    public void AdLoseGame()
    {
        ScoreSet();
        if (_rewardedAd.adNumber > 1)
        {
            panelController.ActivateAdLose();
        }
        else
        {
            panelController.ActivateLose();
        }
    }

    private void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score);
        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score);
        }
        score = 0;
    }
    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }

    public void StartResolveSequence()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }
    
    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2);
        ResolveGame();
    }

    public void RegisterScoreText(TextMeshProUGUI scoreText)
    {
        _scoreText = scoreText;
    }

    public void RegisterPlayerStates(PlayerStates playerStates)
    {
        player = playerStates;
    }

    public void RegisterRewardedAd(RewardedAd ad)
    {
        _rewardedAd = ad;
    }
}
