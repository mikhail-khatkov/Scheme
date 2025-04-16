using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class LevelButton : MonoBehaviour
    {
        public TextWithOutline Text;
        public Image BackgroundImage;
        public Sprite LockedLevelSprite;
        public Sprite OpenedLevelSprite;
        public Color LockedColor;
        public Color OpenedColor;
        
        public void Initialize(int levelNumber, bool opened = true)
        {
            Text.Text = $"{levelNumber}";
            Text.OutlineColor = opened ? OpenedColor : LockedColor;
            BackgroundImage.sprite = opened ? OpenedLevelSprite : LockedLevelSprite;
        }
    }
}