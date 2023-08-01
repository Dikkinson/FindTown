using Leopotam.Ecs;
using DG.Tweening;
using UnityEngine;

internal class RewardSystem : IEcsRunSystem
{
    private EcsFilter<VictoryReward> _ecsFilter;
    private EcsFilter<Timer> _timerFilter;
    private LevelData _levelData;
    private LevelUI _levelUI;

    private float playerTime;

    public void Run()
    {
        foreach (var i in _timerFilter)
        {
            ref var timer = ref _timerFilter.Get1(i);

            playerTime = timer.currentTime;
        }

        foreach (var i in _ecsFilter)
        {
            _ecsFilter.GetEntity(i).Del<VictoryReward>();


            float longestTime = _levelData.levelRewardData[0].seconds;
            int counter = 0;


            _levelUI.victoryScreen.rewardBlock.progressBar.value = 0;
            _levelUI.victoryScreen.rewardBlock.progressBar.maxValue = longestTime;

            _levelUI.victoryScreen.rewardBlock.progressBar.DOValue(longestTime - playerTime, 3f)
            .OnUpdate(() =>
            {
                if (_levelUI.victoryScreen.rewardBlock.progressBar.value > longestTime - _levelData.levelRewardData[counter].seconds)
                {

                    _levelUI.victoryScreen.rewardBlock.rewardsParticles[counter].AnimationState.SetAnimation(0, "animation", false);
                    counter++;
                }

            }).SetAutoKill(true);
        }
    }
}

