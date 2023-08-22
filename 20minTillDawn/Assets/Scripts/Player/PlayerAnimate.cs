using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimationHandler();
    }
    private void AnimationHandler()
    {
        bool isMovingAnimation = animator.GetBool("isMoving");
        bool isHurtAnimation = animator.GetBool("isHurt");
        bool isMoving = PlayerInfo.instance.isMoving;
        bool isHurt = PlayerInfo.instance.CheckPlayerHurt();

        if (isMoving && isMovingAnimation == false)
        {
            animator.SetBool("isMoving", true);
        }
        else if (!isMoving && isMovingAnimation == true)
        {
            animator.SetBool("isMoving", false);
        }

        if (isHurt && isHurtAnimation == false)
        {
            animator.SetBool("isHurt", true);
            isHurt = false;
        }
        else if (!isHurt && isHurtAnimation == true)
        {
            animator.SetBool("isHurt", false);
        }
    }
}
