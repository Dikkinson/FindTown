using Leopotam.Ecs;
using UnityEngine;

public class TimerRunSystem : IEcsRunSystem
{
    private EcsFilter<Timer> _filter;
    private RuntimeData _runtimeData;
    private LevelUI _ui;
    private LevelData _levelData;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var timer = ref _filter.Get1(i);

            timer.currentTime += Time.fixedDeltaTime;

            if (timer.timerType == TimerType.Backward && timer.currentTime >= _levelData.levelTime)
            {
                _runtimeData.CurrentState = GameState.Lose;

                _ui.gameScreen.Show(false);
                _ui.loseScreen.Show();
            }

            float showTime = timer.timerType == TimerType.Forward ? timer.currentTime : _levelData.levelTime - timer.currentTime;

            string minutesStr = string.Format("{0:00}", (int)(showTime / 60));
            string secondsStr = string.Format("{0:00}", (int)(showTime % 60));

            _ui.gameScreen.timerText.text = $"{minutesStr}:{secondsStr}";
        }
    }
}

