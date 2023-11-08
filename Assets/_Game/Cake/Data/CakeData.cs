using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CakeData : ScriptableObject
{
    [SerializeField] private GameObject _cakePrefab;
    [SerializeField] private int _respawnDelay;

    public GameObject CakePrefab { get => _cakePrefab; }
    public int RespawnDelay { get => _respawnDelay; }
}
