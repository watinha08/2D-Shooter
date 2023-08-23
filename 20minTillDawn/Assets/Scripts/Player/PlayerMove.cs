using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float velocity;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        velocity = PlayerInfo.instance.GetPlayerVelocity();
        spriteRenderer = PlayerInfo.instance.GetSpriteRenderer();
    }

    void Update()
    {
        MoveHandler();
    }

    private void MoveHandler()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        transform.Translate(new Vector2(moveX, moveY).normalized * velocity * Time.deltaTime);
        PlayerInfo.instance.isMoving = moveX != 0 || moveY != 0;
        FlipSprite(moveX);
        
    }

    private void FlipSprite(float moveX)
    {
        if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
