using Leopotam.Ecs;
using UnityEngine;

public class MainStartGameSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;

    public void Init()
    {
        if(PlayerPrefs.GetInt("IsNotFirstStart") == 0)
        {
            PlayerPrefs.SetInt("IsNotFirstStart", 1);
            _ecsWorld.NewEntity().Get<PhoneRing>();
        }
        else
        {
            _ecsWorld.NewEntity().Get<UpdateLevelButtons>();
        }
    }
}
