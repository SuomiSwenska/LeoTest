using UnityEngine;
using Leopotam.Ecs;

public class CharacterControlSystem :  IEcsInitSystem, IEcsRunSystem
{
    private EcsWorld _ecsWorld;
    private GameObject _playerGO;
    private EcsEntity _player;
    private AnimatorComponent animator;
    private MovableComponent movable;
    private bl_Joystick _bl_Joystick;

    public void Init()
    {
        InitCharacter();
        _bl_Joystick = GameplayProcess.instance.Bl_Joystick;
    }

    public void Run()
    {
        Vector3 direction = new Vector3(_bl_Joystick.Horizontal, 0, _bl_Joystick.Vertical);

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            movable.characterTransform.rotation = lookRotation;
        }

        movable.characterRigidbody.MovePosition(movable.characterTransform.position += direction * Time.deltaTime * movable.moveSpeed);
        movable.isMoved = direction.magnitude >= 0.1f;
        animator.animator.SetBool("Static_b", !movable.isMoved);
    }

    public void InitCameraFollower(CameraFollower cameraFollower)
    {
        cameraFollower.target = movable.characterTransform;
    }

    private void InitCharacter()
    {
        _ecsWorld = new EcsWorld();
        _player = _ecsWorld.NewEntity();
        movable = _player.Get<MovableComponent>();
        animator = _player.Get<AnimatorComponent>();

        _playerGO = GameObject.Instantiate(GameplayProcess.instance.CharacterInitData.PlayerGOPrefab, Vector3.zero, Quaternion.identity);
        movable.moveSpeed = GameplayProcess.instance.CharacterInitData.MoveSpeed;
        movable.characterTransform = _playerGO.transform;
        movable.characterRigidbody = _playerGO.GetComponent<Rigidbody>();
        animator.animator = _playerGO.transform.GetComponent<Animator>();
    }
}
