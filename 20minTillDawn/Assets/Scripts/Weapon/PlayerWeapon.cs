using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private Transform aimTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform weapon;

    private void Awake()
    {
        aimTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        AimHandler();
        ShootingHandler();
    }

    private void AimHandler()
    {
        Vector3 mousePosition = GameManager.Instance.GetMousePosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle); 
    }

    private void ShootingHandler()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, weapon.position, weapon.rotation);
        }
    }
}
