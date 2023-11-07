using UnityEngine;
using System.Collections.Generic;

public class Table : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    private List<Transform> _busySpawnPoint;

    public bool IsHaveEmptySpawnPoint()
    {
        return _spawnPoints.Count >= 1;
    }

    public void GetEmptySpawnPoint()
    {
        Transform spawnPoint = _spawnPoints[0];
        _spawnPoints.Remove(spawnPoint);
        _busySpawnPoint.Add(spawnPoint);
    }
}
