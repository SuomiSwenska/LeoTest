using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class GameInitSystem : IEcsPreInitSystem, IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem, IEcsPostDestroySystem
{
    private EcsWorld _ecsWorld;
    private GameObject _playerGO;
    private EcsEntity _player;
    private AnimatorComponent animator;
    private MovableComponent movable;
    private bl_Joystick _bl_Joystick;

    public void PreInit()
    {
        throw new System.NotImplementedException();
    }

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

        movable.characterTransform.position += direction * Time.deltaTime * movable.moveSpeed;
        animator.animator.SetBool("Static_b", false);
    }

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public void PostDestroy()
    {
        throw new System.NotImplementedException();
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
        animator.animator = _playerGO.transform.GetComponent<Animator>();
    }
}
