using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CakeData : ScriptableObject
{
    [SerializeField] private GameObject _cakePrefab;

    public GameObject CakePrefab { get => _cakePrefab; }
}
