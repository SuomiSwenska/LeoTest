using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class GameplayProcess : MonoBehaviour
{
    public static GameplayProcess instance;

    [SerializeField] private CharacterInitData _characterInitData;

    private EcsWorld _ecsWorld;
    private GameInitSystem _gameInitSystem;

    public CharacterInitData CharacterInitData { get => _characterInitData; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _gameInitSystem = new GameInitSystem();

        _gameInitSystem.Init();
    }

    private void Update()
    {
        _gameInitSystem.Run();
    }
}
