using UnityEngine;
using System.Threading.Tasks;

public class GameLoopState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly ISceenLoader _sceneLoader;
    private readonly ICharacterService _characterService;
    private readonly IUIFactory _uiFactory;
    private readonly ICharacterFactory _characterFactory;
    private GameUI _gameUI;

    public GameLoopState(StateMachine stateMachine, ISceenLoader sceneLoader, ICharacterService characterService, IUIFactory uiFactory, ICharacterFactory characterFactory)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _characterService = characterService;
        _uiFactory = uiFactory;
        _characterFactory = characterFactory;
    }

    public void Enter()
    {
        LoadGame();
    }

    public void Exit()
    {
        UnsubscribeFromUIEvents();
        ClearGameUI();
    }

    private async void LoadGame()
    {
        await LoadGameScene();
        LoadSelectedCharacter();
        SetupGameUI();
        SubscribeToUIEvents();
    }

    private async Task LoadGameScene()
    {
        await _sceneLoader.LoadAsync(SceneEnum.Game);
    }

    private void LoadSelectedCharacter()
    {
        CharacterData selectedCharacter = _characterService.GetSelectedCharacter();
        _characterFactory.CreateCharacter(selectedCharacter.path);
    }

    private void SetupGameUI()
    {
        _gameUI = _uiFactory.CreateGameUI();
        _gameUI.Init(Camera.main);
    }

    private void SubscribeToUIEvents()
    {
        _gameUI.OnBackButtonClick += OnBackButtonClick;
    }

    private void UnsubscribeFromUIEvents()
    {
        if (_gameUI != null)
        {
            _gameUI.OnBackButtonClick -= OnBackButtonClick;
        }
    }

    private void ClearGameUI()
    {
        _gameUI = null;
    }

    private void OnBackButtonClick()
    {
        _stateMachine.Enter<CharacterSelectorState>();
    }
}
