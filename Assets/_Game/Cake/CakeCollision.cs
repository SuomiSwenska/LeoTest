using System;
using UnityEngine;

public class CakeCollision : MonoBehaviour
{
    private Cake _cake;

    public void InitCakeTrigger(Cake cake)
    {
        _cake = cake;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            _cake.OnCakeTriggerEnter?.Invoke();
        }
    }
}
