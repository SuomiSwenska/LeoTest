using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Leopotam.Ecs;

public class CakeControlSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private GameObject _cakeGO;
    private EcsEntity _cakeEntity;
    private Cake _cake;
    private StackSystem _stackSystem;

    public void Init()
    {
        for (int i = 0; i < GameplayProcess.instance.Table.GetTablePlacesCount(); i++)
        {
            _ecsWorld = new EcsWorld();
            _cakeGO = GameObject.Instantiate(GameplayProcess.instance.CakeData.CakePrefab, GameplayProcess.instance.Table.GetEmptySpawnPoint(), Quaternion.identity);

            _cakeEntity = _ecsWorld.NewEntity();
            _cake = _cakeEntity.Get<Cake>();
            _cake.CakeTransform = _cakeGO.transform;
            _cake.Init();

            CakeCollision cakeCollision = _cakeGO.GetComponent<CakeCollision>();

            cakeCollision.InitCakeTrigger(_cake);
            cakeCollision.OnCakeTriggerEnter += CakeTriggerEnterHandler;
        }

        GameplayProcess.instance.OnDeliveryBoxCollision += ClearCakesStack;
    }

    public void StackSystemImplemeted(StackSystem stackSystem)
    {
        _stackSystem = stackSystem;
    }

    private async void RespawnTask(Cake cake)
    {
        int respawnDelayInSeconds = GameplayProcess.instance.CakeData.RespawnDelay;
        int respawnDelayInMilliseconds = respawnDelayInSeconds * 1000;

        await Task.Delay(respawnDelayInMilliseconds);
        cake.CakeBodyOn();
    }

    private void CakeTriggerEnterHandler(Cake cake)
    { 
        if(!_stackSystem.IsHaveEmptyPlaces())
        {
            Debug.Log("Your inventory is full of cakes, you need to delivery them to delivery box and try again");
            return;
        }

        _stackSystem.AddOneToStack();
        cake.CakeBodyOff();
        RespawnTask(cake);
    }

    private void ClearCakesStack()
    {
        _stackSystem.ClearStack();
    }
}
