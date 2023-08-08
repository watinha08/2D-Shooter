using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity;

    private Animator animator;
    private Transform playerTransform;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * velocity * Time.deltaTime;

        playerTransform.Translate(new Vector3 (moveX, moveY, 0));
    }
}
