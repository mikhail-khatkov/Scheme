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
        public Button ShareBtn;

        protected override void OnAwake()
        {
            PlayBtn.onClick.AddListener(OnPlayBtn);
            CleanBtn.onClick.AddListener(OnCleanBtn);

            if (ShareBtn != null)
                ShareBtn.onClick.AddListener(OnShareBtn);
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

        private void OnShareBtn()
        {
            string url = Application.absoluteURL;
            string text = "Check out Scheme — a fun puzzle game!";
            _telegramService?.ShareUrl(url, text);
        }
    }
}