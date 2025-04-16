using System.Collections.Generic;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using CodeBase.StaticData.Levels;
using CodeBase.UI.Elements;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public sealed class GameplayWindow : WindowBase
    {
        private IWindowService _windowService;
        
        public Image ContentImage;
        public Inventory Inventory;
        public DevicesObserver DevicesObserver;
        public Button MenuButton, TaskButton, ProgressButton, GuideButton;
        
        private Transform _content;
        private Transform _inventoryContent;

        public void Construct(IPersistentProgressService progressService, IGameStateMachine gameStateMachine, IUIFactory uiFactory, ISaveLoadProgressService saveLoadProgressService , IWindowService windowService)
        {
            base.Construct(progressService, gameStateMachine, uiFactory, saveLoadProgressService);
            _windowService = windowService;
        }

        protected override void OnAwake()
        {
            _content = ContentImage.transform;
            _inventoryContent = Inventory.transform;
            
            MenuButton.onClick.AddListener(()=>_gameStateMachine.Enter<LoadMenuState,string>("Main"));
            TaskButton.onClick.AddListener(()=>_windowService.Open(WindowId.InProgress));
            ProgressButton.onClick.AddListener(()=>_windowService.Open(WindowId.InProgress));
            GuideButton.onClick.AddListener(()=>_windowService.Open(WindowId.InProgress));
        }

        public void Initialize(LevelStaticData levelData)
        {
            foreach (OpenWindowButton button in GetComponentsInChildren<OpenWindowButton>())
                button.Construct(_windowService);
            
            _uiFactory.CreateDeviceSpawners(levelData, _content);
            _uiFactory.CreateInventoryItems(levelData, _inventoryContent);

            ContentImage.sprite = levelData.ContentSprite;
            
            DevicesObserver.Construct(_windowService);
            DevicesObserver.Initialize();
            Inventory.Initialize();
        }
    }
}