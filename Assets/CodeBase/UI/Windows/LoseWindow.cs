using CodeBase.Infrastructure.States;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public sealed class LoseWindow : WindowBase
    {
        public Button RestartButton;
        
        protected override void Initialize()
        {
            base.Initialize();

            RestartButton.onClick.AddListener(()=>_gameStateMachine.Enter<LoadLevelState,string>($"Level {_progressService.Progress.GameData.CurrentLevel}"));
        }
    }
}