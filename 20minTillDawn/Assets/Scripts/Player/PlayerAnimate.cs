using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{

    void Update()
    {
        AnimationHandler();
    }
    private void AnimationHandler()
    {
        bool isMovingAnimation = PlayerInfo.instance.animator.GetBool("isMoving");
        bool isHurtAnimation = PlayerInfo.instance.animator.GetBool("isHurt");
        bool isMoving = PlayerInfo.instance.isMoving;
        bool isHurt = PlayerInfo.instance.CheckPlayerHurt();

        if (isMoving && isMovingAnimation == false)
        {
            PlayerInfo.instance.animator.SetBool("isMoving", true);
        }
        else if (!isMoving && isMovingAnimation == true)
        {
            PlayerInfo.instance.animator.SetBool("isMoving", false);
        }

        if (isHurt && isHurtAnimation == false)
        {
            PlayerInfo.instance.animator.SetBool("isHurt", true);
            PlayerInfo.instance.SetPlayerHurt(false);
        }
        else if (!isHurt && isHurtAnimation == true)
        {
            PlayerInfo.instance.animator.SetBool("isHurt", false);
        }
    }
}
