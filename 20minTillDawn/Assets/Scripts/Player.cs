using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private float velocity = 10;
    [SerializeField] private int lives = 3;

    private Animator animator;
    public Transform playerTransform;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;

        playerTransform.Translate(new Vector3 (moveX, moveY, 0));

        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return playerTransform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lives--;
    }
}
