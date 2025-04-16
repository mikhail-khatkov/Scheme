using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadProgressService _saveLoadProgressService;

        public LoadProgressState(IGameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadProgressService saveLoadProgressService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadProgressService = saveLoadProgressService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            
            _gameStateMachine.Enter<LoadMenuState, string>("Main");
        }

        public void Exit()
        {
            
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = 
                _saveLoadProgressService.LoadProgress() 
                ?? NewProgress();
            
            Debug.Log($"Progress = {_progressService.Progress.GameData.MaxLevel} {_progressService.Progress.GameData.CurrentLevel}");
        }

        private PlayerProgress NewProgress()
        {
            PlayerProgress playerProgress = new PlayerProgress();
            playerProgress.GameData.MaxLevel = 17;
            playerProgress.GameData.CompletedLevel = 0;
            playerProgress.GameData.CurrentLevel = 1;
            return playerProgress;
        }
    }
}