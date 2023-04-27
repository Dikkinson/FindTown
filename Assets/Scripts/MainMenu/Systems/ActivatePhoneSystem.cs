using Leopotam.Ecs;

public class ActivatePhoneSystem : IEcsRunSystem
{
    private EcsFilter<PhoneRing> _filter;
    private MainMenuUI _mainMenuUi;
    private MainMenuData _data;

    public void Run()
    {
        foreach (var i in _filter)
        {
            _mainMenuUi.mainMenuWindow.phoneButton.interactable = true;
            _data.phoneGraphic.AnimationState.SetAnimation(0, _data.phoneCallAnimationName, true);

            _filter.GetEntity(i).Del<PhoneRing>();
        }
    }
}
