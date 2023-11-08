using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBoxCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameplayProcess.instance.OnDeliveryBoxCollision.Invoke();
        }
    }
}
