using System;
using Leopotam.Ecs;
using UnityEngine;

public struct Cake : IEcsInitSystem
{
    public Transform CakeTransform;
    public GameObject CakeStackItem;

    private MeshRenderer _meshRenderer;
    private Collider _collider;

    public void Init()
    {
        _meshRenderer = CakeTransform.GetComponent<MeshRenderer>();
        _collider = CakeTransform.GetComponent<Collider>();
    }

    public void CakeBodyOff()
    {
        _meshRenderer.enabled = false;
        _collider.enabled = false;
    }

    public void CakeBodyOn()
    {
        if (_meshRenderer == null) return;
        _meshRenderer.enabled = true;
        _collider.enabled = true;
    }
}
