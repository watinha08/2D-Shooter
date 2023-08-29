using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManger : MonoBehaviour
{
    public static PowerUpManger instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
 