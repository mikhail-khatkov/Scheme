using CodeBase.Infrastructure.States;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public sealed class MenuWindow : WindowBase
    {
        public Button PlayBtn;
        public Button CleanBtn;

        protected override void OnAwake()
        {
            PlayBtn.onClick.AddListener(OnPlayBtn);
            CleanBtn.onClick.AddListener(OnCleanBtn);
        }

        private void OnCleanBtn()
        {
            _progressService.Progress.GameData.CurrentLevel = 1;
            _saveLoadProgressService.SaveProgress();
        }

        private void OnPlayBtn()
        {
            _gameStateMachine.Enter<LoadLevelState, string>($"Level {_progressService.Progress.GameData.CurrentLevel}");
        }
    }
}