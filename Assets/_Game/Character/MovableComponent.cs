using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MovableComponent
{
    public Transform characterTransform;
    public Rigidbody characterRigidbody;
    public float moveSpeed;
    public bool isMoved;
}
