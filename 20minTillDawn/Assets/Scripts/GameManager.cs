using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int gameScore = 0;
    private int playerLifes = 0;

    private void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
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
        UIManager.instance.SetScoreText(gameScore);
    }

    public void SetPlayerLife(int life)
    {
        playerLifes = life;
        UIManager.instance.SetLifesText(playerLifes);
    }
}
