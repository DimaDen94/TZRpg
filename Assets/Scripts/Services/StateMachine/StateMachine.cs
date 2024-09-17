using System.Collections.Generic;
using System;

public class StateMachine
{
    private Dictionary<Type, IState> _states;
    private IState _activeState;

    public StateMachine(ISceenLoader sceeneLoader, IUIFactory uiFactory, ICharacterService characterService, IProgressService progressService, ICharacterFactory characterFactory)
    {
        _states = new Dictionary<Type, IState>()
        {
            [typeof(BootstrapState)] = new BootstrapState(this, characterService, sceeneLoader),
            [typeof(CharacterSelectorState)] = new CharacterSelectorState(this, sceeneLoader, uiFactory, progressService, characterService, characterFactory),
            [typeof(GameLoopState)] = new GameLoopState(this, sceeneLoader, characterService,uiFactory, characterFactory),
        };
    }

    public void Enter<TState>() where TState : IState
    {
        _activeState?.Exit();

        IState state = _states[typeof(TState)];
        _activeState = state;
        state.Enter();
    }
}
