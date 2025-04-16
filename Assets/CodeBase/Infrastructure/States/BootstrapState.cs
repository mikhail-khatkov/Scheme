using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.StaticData;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;

namespace CodeBase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private const string Initial = "Initial";
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;

    public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _services = services;

      RegisterServices(); 
    }

    public void Enter()
    {
      _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
    }

    public void Exit()
    {
    }

    private void RegisterServices()
    {
      RegisterStaticData();
      
      _services.RegisterSingle<IGameStateMachine>(_gameStateMachine);
      _services.RegisterSingle<IAssetProvider>(new AssetProvider());
      _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
      _services.RegisterSingle<ISaveLoadProgressService>(new SaveLoadProgressService(_services.Single<IPersistentProgressService>()));
      
      _services.RegisterSingle<IUIFactory>(new UIFactory(
        _services.Single<IAssetProvider>(),
        _services.Single<IStaticDataService>(),
        _services.Single<IPersistentProgressService>(),
        _services.Single<IGameStateMachine>(),
        _services.Single<ISaveLoadProgressService>()
        ));
      
      _services.RegisterSingle<IWindowService>(new WindowService(_services.Single<IUIFactory>()));
    }

    private void RegisterStaticData()
    {
      IStaticDataService staticData = new StaticDataService();
      staticData.LoadStaticData();
      _services.RegisterSingle(staticData);
    }
    
    private void EnterLoadLevel() =>
      _gameStateMachine.Enter<LoadProgressState>();
  }
}