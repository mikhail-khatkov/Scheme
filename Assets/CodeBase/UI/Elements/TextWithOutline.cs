using TMPro;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class TextWithOutline : MonoBehaviour
    {
        private TMP_Text _text;
        private TMP_Text _outline;


        public Color OutlineColor
        {
            set
            {
                TryInitialize();
                _outline.color = value;
            }
        }

        public string Text
        {
            set
            {
                TryInitialize();
                _text.text = value;
                _outline.text = value;
            }
        }

        private void TryInitialize()
        {
            if (_text != null && _outline != null)
                return;
            
            _text = transform.Find("Text").GetComponent<TMP_Text>();
            _outline = transform.Find("Outline").GetComponent<TMP_Text>();
        }
    }
}