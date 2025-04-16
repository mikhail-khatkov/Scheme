using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public sealed class InProgressWindow : WindowBase
    {
        public Button CloseButton;
        
        protected override void OnAwake() => 
            CloseButton.onClick.AddListener(()=>Destroy(gameObject));
    }
}