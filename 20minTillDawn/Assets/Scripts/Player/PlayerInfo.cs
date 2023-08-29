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
        GameManager.Instance.SetPlayerLife(lifes);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            LifeHandler();
        }
    }

    private void LifeHandler()
    {
        isHurt = true;
        lifes--;
        GameManager.Instance.SetPlayerLife(lifes);
        if (lifes <= 0)
        {
            Destroy(this.gameObject);
        }
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
}
