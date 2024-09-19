using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private GameBootstrapper _gameBootstrapperPrefab;

    public override void InstallBindings()
    {
        BindSceenLoaderService();
        BindAssetProvider();
        BindUIFactory();
        BindCharacterFactory();
        BindJsonConvertor();
        BindProgressService();
        BindCharacterService();
        BindStateMachine();

        //StateMachine stateMachine = Container.Resolve<StateMachine>();
        //stateMachine.Enter<BootstrapState>();
        BindGameBootstrapper();
    }

    private void BindSceenLoaderService() => Container.Bind<ISceenLoader>().To<SceenLoader>().AsSingle();

    private void BindAssetProvider() => Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

    private void BindUIFactory() => Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

    private void BindCharacterFactory() => Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();

    private void BindJsonConvertor() => Container.Bind<IJsonConvertor>().To<JsonConvertor>().AsSingle();

    private void BindProgressService() => Container.Bind<IProgressService>().To<ProgressService>().AsSingle();

    private void BindCharacterService() => Container.Bind<ICharacterService>().To<CharacterService>().AsSingle();

    private void BindStateMachine() => Container.Bind<StateMachine>().To<StateMachine>().AsSingle();

    private void BindGameBootstrapper()
    {
        GameBootstrapper gameBootstrapper = Container.InstantiatePrefabForComponent<GameBootstrapper>(_gameBootstrapperPrefab);
        Container.Bind<GameBootstrapper>().FromInstance(gameBootstrapper).AsSingle();
    }
}