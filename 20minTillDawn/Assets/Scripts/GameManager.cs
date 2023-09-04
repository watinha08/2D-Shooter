using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int gameScore = 0;
    private int playerLifes = 0;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    public int GetGameScore() 
    {
        return gameScore;
    }

    public void SetGameScore(int score)
    {
        gameScore += score;
        PlayerInfo.instance.SetCurrentXP(score);
        UIManager.instance.SetScoreText(gameScore);
    }

    public void SetPlayerLife(int life)
    {
        playerLifes = life;
        UIManager.instance.SetLifesText(playerLifes);
    }

    public void SetLevelInfo(int currentLevel, int currentXP, int toLevelUpXP)
    {
        UIManager.instance.SetXPInfoText(currentXP, toLevelUpXP);
        UIManager.instance.SetPlayerLevelText(currentLevel);
    }

    public void OnLevelUp()
    {
        Time.timeScale = 0;
        UIManager.instance.SetPowerUpContainer(true);
    }
}
