using UnityEngine;
using Leopotam.Ecs;

public class GameplayProcess : MonoBehaviour
{
    public static GameplayProcess instance;

    [SerializeField] private CharacterInitData _characterInitData;
    [SerializeField] private CakeData _cakeData;
    [SerializeField] private bl_Joystick _bl_Joystick;
    [SerializeField] private CameraFollower _cameraFollower;

    private EcsWorld _ecsWorld;
    private CharacterControlSystem _characterControlSystem;

    public CharacterInitData CharacterInitData { get => _characterInitData; }
    public CakeData CakeData { get => _cakeData; }
    public bl_Joystick Bl_Joystick { get => _bl_Joystick; }
    public CameraFollower CameraFollower { get => _cameraFollower; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _characterControlSystem = new CharacterControlSystem();

        _characterControlSystem.Init();
        _characterControlSystem.InitCameraFollower(_cameraFollower);
    }

    private void Update()
    {
        _characterControlSystem.Run();
    }
}
