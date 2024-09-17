using UnityEngine;
using System.Threading.Tasks;

public class CharacterSelectorState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly ISceenLoader _sceneLoader;
    private readonly IUIFactory _uiFactory;
    private readonly IProgressService _progressService;
    private readonly ICharacterService _characterService;
    private readonly ICharacterFactory _characterFactory;
    private CharacterSelectorUI _characterSelectorUI;
    private GameObject _currentCharacter;

    public CharacterSelectorState(StateMachine stateMachine, ISceenLoader sceneLoader, IUIFactory uiFactory, IProgressService progressService,
        ICharacterService characterService, ICharacterFactory characterFactory)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _uiFactory = uiFactory;
        _progressService = progressService;
        _characterService = characterService;
        _characterFactory = characterFactory;
    }

    public void Enter()
    {
        InitializeMenu();
    }

    public void Exit()
    {
        UnsubscribeFromUIEvents();
        ClearUI();
    }

    private async void InitializeMenu()
    {
        await LoadScene();
        SetupUI();
        SubscribeToUIEvents();
    }

    private async Task LoadScene()
    {
        await _sceneLoader.LoadAsync(SceneEnum.CharacterSelector);
    }

    private void SetupUI()
    {
        _characterSelectorUI = _uiFactory.CreateCharacterSelectorUI();
        _characterSelectorUI.Init(Camera.main);
    }

    private void SubscribeToUIEvents()
    {
        _characterSelectorUI.OnCreateButtonClick += OnCreateButtonClick;
        _characterSelectorUI.OnPlayButtonClick += OnPlayButtonClick;
    }

    private void UnsubscribeFromUIEvents()
    {
        if (_characterSelectorUI != null)
        {
            _characterSelectorUI.OnCreateButtonClick -= OnCreateButtonClick;
            _characterSelectorUI.OnPlayButtonClick -= OnPlayButtonClick;
        }
    }

    private void ClearUI() => _characterSelectorUI = null;

    private void OnPlayButtonClick() => _stateMachine.Enter<GameLoopState>();

    private void OnCreateButtonClick()
    {
        DestroyCurrentCharacter();
        CreateNewCharacter();
    }

    private void DestroyCurrentCharacter()
    {
        if (_currentCharacter != null)
        {
            Object.Destroy(_currentCharacter);
        }
    }

    private void CreateNewCharacter()
    {
        CharacterData characterData = _characterService.GetRandomCharacter();
        SaveSelectedCharacter(characterData);
        _currentCharacter = _characterFactory.CreateCharacter(characterData.path);
    }

    private void SaveSelectedCharacter(CharacterData characterData)
    {
        _progressService.SaveSelectedCharacterId(characterData.id);
    }
}
