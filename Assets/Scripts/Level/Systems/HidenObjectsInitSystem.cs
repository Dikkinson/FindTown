using Leopotam.Ecs;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class HidenObjectsInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelData _sceneData;

    public void Init()
    {
        foreach (var levelTask in _sceneData.levelTasks)
        {
            foreach (var hidenObject in levelTask.taskObjects)
            {
                var hidenObjectEntity = _ecsWorld.NewEntity();

                ref var hidenObjectComponent = ref hidenObjectEntity.Get<HidenObject>();

                hidenObject.hidenObjectEntity = hidenObjectEntity;
                hidenObjectComponent.animator = hidenObject.GetComponent<Animator>();
                hidenObjectComponent.itemIndex = levelTask.itemIndex;

                if (_sceneData.hideSpotsList.Count == 0) continue;

                var hideSpot = _sceneData.hideSpotsList.Where(x => x.hidenObjectsVariants.Contains(hidenObject.gameObject)).Where(x => x.transform.childCount == 0).ToList();

                int randomIndex = Random.Range(0, hideSpot.Count);

                hidenObject.transform.position = hideSpot[randomIndex].transform.position;
                hidenObject.GetComponent<SpriteRenderer>().sortingOrder += (int)hideSpot[randomIndex].itemPosition;
                hidenObject.transform.parent = hideSpot[randomIndex].transform;
            }
        }
    }
}

