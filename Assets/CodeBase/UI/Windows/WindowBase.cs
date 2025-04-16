using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.States;
using CodeBase.StaticData;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        protected IPersistentProgressService _progressService;
        protected IGameStateMachine _gameStateMachine;
        protected IUIFactory _uiFactory;
        protected ISaveLoadProgressService _saveLoadProgressService;
        protected PlayerProgress Progress => _progressService.Progress;
        
        public void Construct(IPersistentProgressService progressService, IGameStateMachine gameStateMachine, IUIFactory uiFactory, ISaveLoadProgressService saveLoadProgressService)
        {
            _progressService = progressService;
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _saveLoadProgressService = saveLoadProgressService;
        }

        private void Awake() => 
            OnAwake();

        private void Start()
        {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy() => 
            CleanUp();

        protected virtual void OnAwake() {}

        protected virtual void Initialize() {}

        protected virtual void SubscribeUpdates() {}

        protected virtual void CleanUp() {}
    }
}