using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        IncreaseSize,
        Laser
    }

    [SerializeField] private PowerUpType powerUpType;
    [SerializeField] private float speed = 5;

    private void Update()
    {
        transform.position += Vector3.down * (Time.deltaTime * speed);
    }
}
