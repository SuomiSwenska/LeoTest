using Leopotam.Ecs;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class StackSystem
{
    public void AddOneToStack()
    {
        GameObject uiItemInactive = GameplayProcess.instance.UiItems.FirstOrDefault(item => !item.activeSelf);
        uiItemInactive.SetActive(true);
    }

    public async void ClearStack()
    {
        foreach (var item in GameplayProcess.instance.UiItems)
        {
            item.SetActive(false);
            await Task.Delay(100);
        }
    }

    public bool IsHaveEmptyPlaces()
    {
        GameObject uiItemInactive = GameplayProcess.instance.UiItems.FirstOrDefault(item => !item.activeSelf);
        return uiItemInactive != null;
    }
}
