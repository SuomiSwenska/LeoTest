using System;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class GameplayProcess : MonoBehaviour
{
    public static GameplayProcess instance;

    public Action OnDeliveryBoxCollision;

    #region Datas
    [SerializeField] private CharacterInitData _characterInitData;
    [SerializeField] private CakeData _cakeData;
    [Space(10)]
    [SerializeField] private bl_Joystick _bl_Joystick;
    [SerializeField] private CameraFollower _cameraFollower;
    [SerializeField] private Table _table;
    [SerializeField] private List<GameObject> _uiItems;
    #endregion

    #region Systems
    private EcsWorld _ecsWorld;
    private CharacterControlSystem _characterControlSystem;
    private CakeControlSystem _cakeControlSystem;
    private StackSystem _stackSystem;
    #endregion

    #region Getters
    public CharacterInitData CharacterInitData { get => _characterInitData; }
    public CakeData CakeData { get => _cakeData; }
    public bl_Joystick Bl_Joystick { get => _bl_Joystick; }
    public CameraFollower CameraFollower { get => _cameraFollower; }
    public Table Table { get => _table; }
    public List<GameObject> UiItems { get => _uiItems; }
    #endregion

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _characterControlSystem = new CharacterControlSystem();

        _stackSystem = new StackSystem();

        _cakeControlSystem = new CakeControlSystem();
        _cakeControlSystem.Init();
        _cakeControlSystem.StackSystemImplemeted(_stackSystem);

        _characterControlSystem.Init();
        _characterControlSystem.InitCameraFollower(_cameraFollower);
    }

    private void Update()
    {
        _characterControlSystem.Run();
    }
}
