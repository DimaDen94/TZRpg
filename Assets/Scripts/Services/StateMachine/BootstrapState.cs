public class BootstrapState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly ICharacterService _characterService;
    private readonly ISceenLoader _sceneLoader;

    public BootstrapState(StateMachine stateMachine, ICharacterService characterService, ISceenLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _characterService = characterService;
        _sceneLoader = sceneLoader;
    }

    public async void Enter()
    {
        await _sceneLoader.LoadAsync(SceneEnum.CharacterSelector);
        _characterService.LoadResources();
        _stateMachine.Enter<CharacterSelectorState>();
    }

    public void Exit() { }
}
