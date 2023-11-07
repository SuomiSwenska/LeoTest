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

    public void PreInit()
    {
        throw new System.NotImplementedException();
    }

    public void Init()
    {
        InitCharacter();

    }

    public void Run()
    {
        movable.characterTransform.position += Vector3.forward * Time.deltaTime * movable.moveSpeed;
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
