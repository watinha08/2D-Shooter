using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float velocity = 5;
    [SerializeField] private int enemyLife = 1;
    private int lives;
    private Transform enemyTransform;

    private Vector2 targetPosition;

    private void Awake()
    {
        enemyTransform = GetComponent<Transform>();
    }

    void Update()
    {
        targetPosition = PlayerInfo.instance.GetPlayerPosition();
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeHandler(collision);
    }

    private void LifeHandler(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            enemyLife--;
            GameManager.instance.SetGameScore(1);
        }
        if (enemyLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}