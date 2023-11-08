using UnityEngine;
using System.Collections.Generic;

public class Table : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    private List<Transform> _busySpawnPoint;
    private int _pointCount;

    private void Awake()
    {
        _busySpawnPoint = new List<Transform>();
    }

    public bool IsHaveEmptySpawnPoint()
    {
        return _spawnPoints.Count >= 1;
    }

    public Vector3 GetEmptySpawnPoint()
    {
        Transform spawnPoint = _spawnPoints[_pointCount];
        _busySpawnPoint.Add(spawnPoint);
        _pointCount++;
        return spawnPoint.position;
    }

    public int GetTablePlacesCount()
    {
        return _spawnPoints.Count;
    }
}
