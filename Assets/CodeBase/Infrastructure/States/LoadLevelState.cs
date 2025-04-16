using System.Collections.Generic;
using System.Linq;
using CodeBase.Logic;
using CodeBase.StaticData;
using CodeBase.StaticData.Device;
using CodeBase.StaticData.Levels;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using static CodeBase.Infrastructure.AssetManagement.TagsConstants;

namespace CodeBase.Infrastructure.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _loadingCurtain;
    private readonly IUIFactory _uiFactory;
    private readonly IStaticDataService _staticData;
    private readonly IWindowService _windowService;

    public LoadLevelState(GameStateMachine gameGameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IUIFactory uiFactory, IStaticDataService staticData, IWindowService windowService)
    {
      _gameStateMachine = gameGameStateMachine;
      _sceneLoader = sceneLoader;
      _loadingCurtain = loadingCurtain;
      _uiFactory = uiFactory;
      _staticData = staticData;
      _windowService = windowService;
    }

    public void Enter(string sceneName)
    {
      _loadingCurtain.Show();
      _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit() =>
      _loadingCurtain.Hide();

    private void OnLoaded()
    {
      InitGameWorld();
      
      _gameStateMachine.Enter<GameLoopState>();
    }
    
    private void InitGameWorld()
    {
      LevelStaticData levelData = LevelStaticData();

      InitUIRoot();
      HideTechnicalObjects();
      InitGameplayWindow(levelData);
    }

    private LevelStaticData LevelStaticData() => 
      _staticData.ForLevel(SceneManager.GetActiveScene().name);

    private void InitUIRoot() => 
      _uiFactory.CreateUIRoot();

    private void HideTechnicalObjects()
    {
        List<GameObject> techObjects = GameObject.FindGameObjectsWithTag(tag: Tech).ToList();
        techObjects.ForEach(techObject => techObject.SetActive(false));
    }

    private void InitGameplayWindow(LevelStaticData levelData) => 
      _uiFactory.CreateGameplayWindow(levelData, _windowService);
  }
}