using Leopotam.Ecs;
using UnityEngine;

public class TimerRunSystem : IEcsRunSystem
{
    private EcsFilter<Timer> _filter;
    private RuntimeData _runtimeData;
    private LevelUI _ui;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var timer = ref _filter.Get1(i);

            switch (timer.timerType)
            {
                case TimerType.Forward:
                    timer.currentTime += Time.fixedDeltaTime;
                    break;
                case TimerType.Backward:
                    timer.currentTime -= Time.fixedDeltaTime;
                    break;
            }

            if (timer.timerType == TimerType.Backward && timer.currentTime <= 0f)
            {
                _runtimeData.CurrentState = GameState.Lose;

                _ui.gameScreen.Show(false);
                _ui.loseScreen.Show();
            }

            string minutesStr = string.Format("{0:00}", (int)(timer.currentTime / 60));
            string secondsStr = string.Format("{0:00}", (int)(timer.currentTime % 60));

            _ui.gameScreen.timerText.text = $"{minutesStr}:{secondsStr}";
        }
    }
}

