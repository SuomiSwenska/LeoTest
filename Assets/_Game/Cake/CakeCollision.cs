using System;
using UnityEngine;

public class CakeCollision : MonoBehaviour
{
    public Action<Cake> OnCakeTriggerEnter;
    private Cake _cake;

    public void InitCakeTrigger(Cake cake)
    {
        _cake = cake;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnCakeTriggerEnter?.Invoke(_cake);
        }
    }
}
