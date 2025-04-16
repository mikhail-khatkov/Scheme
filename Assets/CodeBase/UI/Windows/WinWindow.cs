using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.States;
using CodeBase.UI.Services.Factory;
using TMPro;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public sealed class WinWindow : WindowBase
    {
        public Button ContinueButton;
        public TMP_Text LevelNumberText, LevelNumberTextOutline;

        protected override void Initialize()
        {
            base.Initialize();

            LevelNumberText.text = LevelNumberTextOutline.text = $"{_progressService.Progress.GameData.CurrentLevel}";
            _progressService.Progress.GameData.ExtendLevel();
            _saveLoadProgressService.SaveProgress();
            ContinueButton.onClick.AddListener(()=>_gameStateMachine.Enter<LoadLevelState,string>($"Level {_progressService.Progress.GameData.CurrentLevel}"));
        }
    }
}