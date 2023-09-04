using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Containers")]
    [SerializeField] private Transform powerUpContainer;

    [Header ("Top View Text")]
    [SerializeField] private TextMeshProUGUI lifesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI XPInfoText;
    [SerializeField] private TextMeshProUGUI currentLevelXPText;

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
        SetupUI();
        #endregion
    }

    private void SetupUI()
    {
        lifesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);

        SetPowerUpContainer(false);
    }

    public void SetPowerUpContainer(bool isActive)
    {
        powerUpContainer.gameObject.SetActive(isActive);
    }

    public void SetScoreText(int updatedScore)
    {
        scoreText.text = "Score: " + updatedScore;
    }

    public void SetLifesText(int updatedLife)
    {
        lifesText.text = "Lifes: " + updatedLife;
    }

    public void SetXPInfoText(int currentXP, int toLevelUpXP)
    {
        XPInfoText.text = currentXP + " / " + toLevelUpXP;
    }

    public void SetPlayerLevelText(int newLevel)
    {
        currentLevelXPText.text = "Level " + newLevel.ToString();
    }
}
