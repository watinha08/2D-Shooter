using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    [SerializeField] private int lifes = 3;
    [SerializeField] private float playerVelocity = 10;

    private SpriteRenderer spritePlayer;
    private Transform playerTransform;
    private SpriteRenderer spriteRenderer;
    private bool isHurt;
    public bool isMoving;

    private int playerLevel;
    private int currentPlayerXP;
    private int toLevelUpXP = 10;

    public Animator animator {get; set;}

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
        playerTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.instance.SetPlayerLife(lifes);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            LifeHandler(-1);
        }
    }

    public void LifeHandler(int value)
    {
        if(value > 0)
        {
            lifes += value;
        }
        else
        {
            isHurt = true;
            lifes += value;
            if (lifes <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        GameManager.instance.SetPlayerLife(lifes);
    }

    public Vector2 GetPlayerPosition()
    {
        return playerTransform.position;
    }

    public float GetPlayerVelocity()
    {
        return playerVelocity;
    }

    public bool CheckPlayerVelocity()
    {
        return isMoving;
    }

    public bool CheckPlayerHurt()
    {
        return isHurt;
    }

    public void SetPlayerHurt(bool hurt)
    {
         isHurt = hurt;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    public void SetCurrentXP(int xpToAdd)
    {
        currentPlayerXP += xpToAdd;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if (currentPlayerXP >= toLevelUpXP)
        {
            playerLevel++;
            currentPlayerXP -= toLevelUpXP;
            toLevelUpXP += 5;
            GameManager.instance.OnLevelUp();
        }
        GameManager.instance.SetLevelInfo(playerLevel, currentPlayerXP, toLevelUpXP);
    }
}
